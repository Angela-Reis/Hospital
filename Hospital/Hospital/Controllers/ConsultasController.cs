using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Hospital.Controllers
{
    [Authorize]
    [Authorize(Roles = "Administrativo, Medico, Utente")]
    public class ConsultasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UtilizadorApp> _userManager;
        public ConsultasController(ApplicationDbContext context, UserManager<UtilizadorApp> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            List<Consultas> consultas = null;
            // obtem o id do utilizador
            string utilID = _userManager.GetUserId(User);
            if (User.IsInRole("Utente"))
            {
                //mostrar apenas consulta do proprio utente
                consultas = await _context.Consultas.Where(c => c.Utente.IdUtilizador == utilID)
                    .Include(c => c.Diagnostico)
                    .Include(c => c.Medico)
                    .Include(c => c.Utente).ToListAsync();
            }
            else if (User.IsInRole("Medico"))
            {
                //mostrar apenas consulta do médico 
                consultas = await _context.Consultas.Where(c => c.Medico.IdUtilizador == utilID)
                    .Include(c => c.Diagnostico)
                    .Include(c => c.Medico)
                    .Include(c => c.Utente).ToListAsync();
            }
            else
            {
                consultas = await _context.Consultas
                    .Include(c => c.Diagnostico)
                    .Include(c => c.Medico)
                    .Include(c => c.Utente).ToListAsync();
            }
            return View(consultas);
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consultas == null)
            {
                return NotFound();
            }
            Consultas consulta = null;
            // obtem o id do utilizador
            string utilID = _userManager.GetUserId(User);
            if (User.IsInRole("Utente"))
            {
                //mostrar apenas consulta do proprio utente
                consulta = await _context.Consultas.Where(c => c.Utente.IdUtilizador == utilID)
                    .Include(c => c.Diagnostico)
                    .Include(c => c.Medico)
                    .Include(c => c.Utente).FirstOrDefaultAsync(m => m.Id == id); ;
            }
            else if (User.IsInRole("Medico"))
            {
                //mostrar apenas consulta do médico 
                consulta = await _context.Consultas.Where(c => c.Medico.IdUtilizador == utilID)
                    .Include(c => c.Diagnostico)
                    .Include(c => c.Medico)
                    .Include(c => c.Utente).FirstOrDefaultAsync(m => m.Id == id); ;
            }
            else
            {
                consulta = await _context.Consultas
                    .Include(c => c.Diagnostico)
                    .Include(c => c.Medico)
                    .Include(c => c.Utente).FirstOrDefaultAsync(m => m.Id == id); ;
            }
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Titulo");
            ViewData["MedicoFK"] = new SelectList(_context.Medicos, "Id", "Nome");
            ViewData["UtenteFK"] = new SelectList(_context.Utentes, "Id", "Nome");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Motivo,Estado,UtenteFK,MedicoFK,DiagnosticoFK")] Consultas consulta)
        {
            if (User.IsInRole("Utente"))
            {
                string utilID = _userManager.GetUserId(User);
                var utente = await _context.Utentes.Where(u => u.IdUtilizador == utilID).FirstOrDefaultAsync();
                //se o utilizador é do Role Utente quando marca consulta esta fica pendente
                consulta.Estado = "P";
                consulta.UtenteFK = utente.Id;
            }
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Titulo", consulta.DiagnosticoFK);
            ViewData["MedicoFK"] = new SelectList(_context.Medicos, "Id", "Nome", consulta.MedicoFK);
            ViewData["UtenteFK"] = new SelectList(_context.Utentes, "Id", "Nome", consulta.UtenteFK);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consultas == null)
            {
                return NotFound();
            }

            var consultas = await _context.Consultas.FindAsync(id);
            if (consultas == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Utente"))
            {
                return RedirectToAction("Cancel", consultas);

            }

            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Titulo", consultas.DiagnosticoFK);
            ViewData["MedicoFK"] = new SelectList(_context.Medicos, "Id", "Nome", consultas.MedicoFK);
            ViewData["UtenteFK"] = new SelectList(_context.Utentes, "Id", "Nome", consultas.UtenteFK);
            //variavel de sessão que guarda o id da consulta a ser editada
            HttpContext.Session.SetInt32("ConsultaEditId", consultas.Id);


            return View(consultas);
        }

        public async Task<IActionResult> Cancel(Consultas consulta)
        {
            if (consulta == null || _context.Consultas == null)
            {
                return NotFound();
            }
            consulta.Estado = "C";
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultasExists(consulta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Motivo,Estado,UtenteFK,MedicoFK,DiagnosticoFK")] Consultas consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }
            //verifica se o id previamente guardado é igual ao devolvido após as mudanças
            var previoGuardada = HttpContext.Session.GetInt32("ConsultaEditId");

            if (previoGuardada == null)
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return View(consulta);
            }

            if (previoGuardada != consulta.Id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultasExists(consulta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Titulo", consulta.DiagnosticoFK);
            ViewData["MedicoFK"] = new SelectList(_context.Medicos, "Id", "Nome", consulta.MedicoFK);
            ViewData["UtenteFK"] = new SelectList(_context.Utentes, "Id", "Nome", consulta.UtenteFK);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consultas == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Diagnostico)
                .Include(c => c.Medico)
                .Include(c => c.Utente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }
            //guardar o id da consulta a ser apagada
            HttpContext.Session.SetInt32("ConsultaDeleteId", consulta.Id);

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consultas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Consultas'  is null.");
            }
            var consultas = await _context.Consultas.FindAsync(id);

            //consultar o id previamente guardado da consulta a apagar
            var previoGuardado = HttpContext.Session.GetInt32("ConsultaDeleteId");
            //verificar se o id da consulta a apagar previamente guardada é igual à atual
            if (previoGuardado == null || (previoGuardado != consultas.Id))
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return RedirectToAction("Index");
            }

            if (consultas != null)
            {
                _context.Consultas.Remove(consultas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultasExists(int id)
        {
          return _context.Consultas.Any(e => e.Id == id);
        }
    }
}
