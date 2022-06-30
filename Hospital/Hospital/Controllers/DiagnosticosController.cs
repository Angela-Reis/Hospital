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
    public class DiagnosticosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UtilizadorApp> _userManager;

        public DiagnosticosController(ApplicationDbContext context, UserManager<UtilizadorApp> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Diagnosticos
        public async Task<IActionResult> Index()
        {
            List<Diagnosticos> diagnosticos = null;
            // obtem o id do utilizador
            string utilID = _userManager.GetUserId(User);
            //Redireciona os Utentes para a sua pagina de Detalhes
            if (User.IsInRole("Utente"))
            {
                //moatrar apenas diagnósticos do proprio utente
                diagnosticos = await _context.Diagnosticos.Include(d => d.ListaConsultas)
                    .Where(d => d.ListaConsultas
                    .Any(c => c.Utente.IdUtilizador == utilID))
                    .ToListAsync();
            }
            else if (User.IsInRole("Medico"))
            {
                //mostrar apenas utentes com que o médico já teve consultas
                diagnosticos = await _context.Diagnosticos.Include(d => d.ListaConsultas)
                    .Where(u => u.ListaConsultas
                    .Any(l => l.Medico.IdUtilizador == utilID))
                    .ToListAsync();
            }
            else
            {
                diagnosticos = await _context.Diagnosticos.Include(d => d.ListaConsultas).ToListAsync();
            }

            return View(diagnosticos);
        }

        // GET: Diagnosticos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Diagnosticos == null)
            {
                return NotFound();
            }
            Diagnosticos diagnostico = null;
            string utilID = _userManager.GetUserId(User);
            if (User.IsInRole("Utente"))
            {

                diagnostico = await _context.Diagnosticos.Include(d => d.ListaConsultas)
                    .Where(d => d.ListaConsultas
                    .Any(c => c.Utente.IdUtilizador == utilID))
                    .FirstOrDefaultAsync(m => m.Id == id);

            }
            else if (User.IsInRole("Medico"))
            {
                diagnostico = await _context.Diagnosticos.Include(d => d.ListaConsultas)
                    .Where(u => u.ListaConsultas
                    .Any(l => l.Medico.IdUtilizador == utilID))
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                diagnostico = await _context.Diagnosticos.Include(d => d.ListaConsultas).FirstOrDefaultAsync(m => m.Id == id);
            }

            if (diagnostico == null)
            {
                return NotFound();
            }

            return View(diagnostico);
        }

        // GET: Diagnosticos/Create
        [Authorize(Roles = "Administrativo, Medico")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diagnosticos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo, Medico")]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Estado")] Diagnosticos diagnosticos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diagnosticos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diagnosticos);
        }

        // GET: Diagnosticos/Edit/5
        [Authorize(Roles = "Administrativo, Medico")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Diagnosticos == null)
            {
                return NotFound();
            }

            var diagnosticos = await _context.Diagnosticos.FindAsync(id);
            if (diagnosticos == null)
            {
                return NotFound();
            }

            //guardar o id da especialidade a ser editada numa variavel de sessão
            HttpContext.Session.SetInt32("EditDiagId", diagnosticos.Id);

            return View(diagnosticos);
        }

        // POST: Diagnosticos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo, Medico")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Estado")] Diagnosticos diagnosticos)
        {
            if (id != diagnosticos.Id)
            {
                return NotFound();
            }

            var previoGuardada = HttpContext.Session.GetInt32("EditDiagId");
            //verificar se o id é igual ao guardado anteriormente
            if (previoGuardada == null)
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return View(diagnosticos);
            }

            if (previoGuardada != diagnosticos.Id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnosticos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosticosExists(diagnosticos.Id))
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
            return View(diagnosticos);
        }

        // GET: Diagnosticos/Delete/5
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Diagnosticos == null)
            {
                return NotFound();
            }

            var diagnosticos = await _context.Diagnosticos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diagnosticos == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32("DeleteDiagId", diagnosticos.Id);

            return View(diagnosticos);
        }

        // POST: Diagnosticos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (_context.Diagnosticos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Diagnosticos'  is null.");
            }
            var diagnosticos = await _context.Diagnosticos.FindAsync(id);

            //Verificar se o valor do id não foi alterado
            var previoGuardada = HttpContext.Session.GetInt32("DeleteDiagId");
            if (previoGuardada == null)
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return View(diagnosticos);
            }
            if (previoGuardada != diagnosticos.Id)
            {
                return RedirectToAction("Index");
            }


            if (diagnosticos != null)
            {
                _context.Diagnosticos.Remove(diagnosticos);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiagnosticosExists(int id)
        {
            return _context.Diagnosticos.Any(e => e.Id == id);
        }
    }
}
