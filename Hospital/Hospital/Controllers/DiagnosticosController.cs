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
    public class DiagnosticosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiagnosticosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Diagnosticos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Diagnosticos.ToListAsync());
        }

        // GET: Diagnosticos/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(diagnosticos);
        }

        // GET: Diagnosticos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diagnosticos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Estado")] Diagnosticos diagnosticos)
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
            return View(diagnosticos);
        }

        // POST: Diagnosticos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Estado")] Diagnosticos diagnosticos)
        {
            if (id != diagnosticos.Id)
            {
                return NotFound();
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

            return View(diagnosticos);
        }

        // POST: Diagnosticos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Diagnosticos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Diagnosticos'  is null.");
            }
            var diagnosticos = await _context.Diagnosticos.FindAsync(id);
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
