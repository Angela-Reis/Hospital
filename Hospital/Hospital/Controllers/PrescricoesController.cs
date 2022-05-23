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
    public class PrescricoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrescricoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prescricoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Prescricoes.Include(p => p.Diagnostico);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Prescricoes/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(prescricoes);
        }

        // GET: Prescricoes/Create
        public IActionResult Create()
        {
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Descricao");
            return View();
        }

        // POST: Prescricoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Data,Estado,DiagnosticoFK")] Prescricoes prescricoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescricoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Descricao", prescricoes.DiagnosticoFK);
            return View(prescricoes);
        }

        // GET: Prescricoes/Edit/5
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
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Descricao", prescricoes.DiagnosticoFK);
            return View(prescricoes);
        }

        // POST: Prescricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Data,Estado,DiagnosticoFK")] Prescricoes prescricoes)
        {
            if (id != prescricoes.Id)
            {
                return NotFound();
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
            ViewData["DiagnosticoFK"] = new SelectList(_context.Diagnosticos, "Id", "Descricao", prescricoes.DiagnosticoFK);
            return View(prescricoes);
        }

        // GET: Prescricoes/Delete/5
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

            return View(prescricoes);
        }

        // POST: Prescricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prescricoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Prescricoes'  is null.");
            }
            var prescricoes = await _context.Prescricoes.FindAsync(id);
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
