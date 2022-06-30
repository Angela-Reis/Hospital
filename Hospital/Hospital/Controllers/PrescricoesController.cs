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
    public class PrescricoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UtilizadorApp> _userManager;

        public PrescricoesController(ApplicationDbContext context, UserManager<UtilizadorApp> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Prescricoes
        public async Task<IActionResult> Index()
        {
            List<Prescricoes> prescricoes = null;
            // obtem o id do utilizador
            string utilID = _userManager.GetUserId(User);
            //Redireciona os Utentes para a sua pagina de Detalhes
            if (User.IsInRole("Utente"))
            {
                //moatrar apenas precricoes do proprio utente
                prescricoes = await _context.Prescricoes
                    .Include(p => p.Diagnostico)
                    .Where(p => p.Diagnostico.ListaConsultas
                    .Any(l => l.Utente.IdUtilizador == utilID)).ToListAsync();
            }
            else if (User.IsInRole("Medico"))
            {
                //mostrar apenas utentes com que o médico já teve consultas
                prescricoes = await _context.Prescricoes
                    .Include(p => p.Diagnostico)
                    .Where(p => p.Diagnostico.ListaConsultas
                    .Any(l => l.Medico.IdUtilizador == utilID)).ToListAsync();
            }
            else
            {
                prescricoes = await _context.Prescricoes.Include(p => p.Diagnostico).ToListAsync();
            }
            return View(prescricoes);
        }

        // GET: Prescricoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prescricoes == null)
            {
                return NotFound();
            }

            Prescricoes prescricoes = null;
            // obtem o id do utilizador
            string utilID = _userManager.GetUserId(User);
            //Redireciona os Utentes para a sua pagina de Detalhes
            if (User.IsInRole("Utente"))
            {
                //moatrar apenas precricoes do proprio utente
                prescricoes = await _context.Prescricoes
                    .Include(p => p.Diagnostico)
                    .Where(p => p.Diagnostico.ListaConsultas
                    .Any(l => l.Utente.IdUtilizador == utilID)).FirstOrDefaultAsync(m => m.Id == id);
            }
            else if (User.IsInRole("Medico"))
            {
                //mostrar apenas utentes com que o médico já teve consultas
                prescricoes = await _context.Prescricoes
                    .Include(p => p.Diagnostico)
                    .Where(p => p.Diagnostico.ListaConsultas
                    .Any(l => l.Medico.IdUtilizador == utilID)).FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                prescricoes = await _context.Prescricoes.Include(p => p.Diagnostico).FirstOrDefaultAsync(m => m.Id == id);
            }

            if (prescricoes == null)
            {
                return NotFound();
            }

            return View(prescricoes);
        }

        // GET: Prescricoes/Create
        [Authorize(Roles = "Administrativo, Medico")]
        public IActionResult Create()
        {
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Titulo");
            return View();
        }

        // POST: Prescricoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo, Medico")]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Data,Estado,DiagnosticoFK")] Prescricoes prescricoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescricoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Titulo", prescricoes.DiagnosticoFK);
            return View(prescricoes);
        }

        // GET: Prescricoes/Edit/5
        [Authorize(Roles = "Administrativo, Medico")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prescricoes == null)
            {
                return NotFound();
            }

            var prescricoes = await _context.Prescricoes.FindAsync(id);
            if (prescricoes == null)
            {
                return NotFound();
            }
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Titulo", prescricoes.DiagnosticoFK);
            //guardar validade de sessão com o id
            HttpContext.Session.SetInt32("EditPrescId", prescricoes.Id);
            return View(prescricoes);
        }

        // POST: Prescricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo, Medico")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Data,Estado,DiagnosticoFK")] Prescricoes prescricoes)
        {
            if (id != prescricoes.Id)
            {
                return NotFound();
            }

            var previoGuardada = HttpContext.Session.GetInt32("EditPrescId");
            //verificar se o id é igual ao guardado anteriormente
            if (previoGuardada == null)
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return View(prescricoes);
            }

            if (previoGuardada != prescricoes.Id)
            {
                return RedirectToAction("Index");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescricoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescricoesExists(prescricoes.Id))
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
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Titulo", prescricoes.DiagnosticoFK);
            return View(prescricoes);
        }

        // GET: Prescricoes/Delete/5
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prescricoes == null)
            {
                return NotFound();
            }

            var prescricoes = await _context.Prescricoes
                .Include(p => p.Diagnostico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescricoes == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32("DeletePrescId", prescricoes.Id);

            return View(prescricoes);
        }

        // POST: Prescricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prescricoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Prescricoes'  is null.");
            }
            var prescricoes = await _context.Prescricoes.FindAsync(id);

            //verificar se o id é igual ao guardado anteriormente na variável de sessão
            var previoGuardada = HttpContext.Session.GetInt32("DeletePrescId");
            if (previoGuardada == null)
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return View(prescricoes);
            }

            if (previoGuardada != prescricoes.Id)
            {
                return RedirectToAction("Index");
            }


            if (prescricoes != null)
            {
                _context.Prescricoes.Remove(prescricoes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescricoesExists(int id)
        {
            return _context.Prescricoes.Any(e => e.Id == id);
        }
    }
}
