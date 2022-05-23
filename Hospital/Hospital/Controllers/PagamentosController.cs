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
    public class PagamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pagamentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pagamentos.Include(p => p.Consulta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamentos = await _context.Pagamentos
                .Include(p => p.Consulta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamentos == null)
            {
                return NotFound();
            }

            return View(pagamentos);
        }

        // GET: Pagamentos/Create
        public IActionResult Create()
        {
            ViewData["ConsultaFK"] = new SelectList(_context.Consultas, "Id", "Motivo");
            return View();
        }

        // POST: Pagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,Descricao,Estado,DataEfetuado,Metodo,ConsultaFK")] Pagamentos pagamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultaFK"] = new SelectList(_context.Consultas, "Id", "Motivo", pagamentos.ConsultaFK);
            return View(pagamentos);
        }

        // GET: Pagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamentos = await _context.Pagamentos.FindAsync(id);
            if (pagamentos == null)
            {
                return NotFound();
            }
            ViewData["ConsultaFK"] = new SelectList(_context.Consultas, "Id", "Motivo", pagamentos.ConsultaFK);
            return View(pagamentos);
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,Descricao,Estado,DataEfetuado,Metodo,ConsultaFK")] Pagamentos pagamentos)
        {
            if (id != pagamentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentosExists(pagamentos.Id))
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
            ViewData["ConsultaFK"] = new SelectList(_context.Consultas, "Id", "Motivo", pagamentos.ConsultaFK);
            return View(pagamentos);
        }

        // GET: Pagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamentos = await _context.Pagamentos
                .Include(p => p.Consulta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamentos == null)
            {
                return NotFound();
            }

            return View(pagamentos);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagamentos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pagamentos'  is null.");
            }
            var pagamentos = await _context.Pagamentos.FindAsync(id);
            if (pagamentos != null)
            {
                _context.Pagamentos.Remove(pagamentos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentosExists(int id)
        {
          return _context.Pagamentos.Any(e => e.Id == id);
        }
    }
}
