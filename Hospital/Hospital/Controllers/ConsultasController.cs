using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consultas.Include(c => c.Diagnostico).Include(c => c.Medico).Include(c => c.Utente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consultas == null)
            {
                return NotFound();
            }

            var consultas = await _context.Consultas
                .Include(c => c.Diagnostico)
                .Include(c => c.Medico)
                .Include(c => c.Utente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultas == null)
            {
                return NotFound();
            }

            return View(consultas);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Descricao");
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
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Descricao", consulta.DiagnosticoFK);
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
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Descricao", consultas.DiagnosticoFK);
            ViewData["MedicoFK"] = new SelectList(_context.Medicos, "Id", "Nome", consultas.MedicoFK);
            ViewData["UtenteFK"] = new SelectList(_context.Utentes, "Id", "Nome", consultas.UtenteFK);
            //variavel de sessão que guarda o id da consulta a ser editada
            HttpContext.Session.SetInt32("ConsultaEditId", consultas.Id);
            return View(consultas);
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
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Descricao", consulta.DiagnosticoFK);
            ViewData["MedicoFK"] = new SelectList(_context.Medicos, "Id", "Nome", consulta.MedicoFK);
            ViewData["UtenteFK"] = new SelectList(_context.Utentes, "Id", "Nome", consulta.UtenteFK);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
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
