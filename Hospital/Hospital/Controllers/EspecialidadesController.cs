﻿using System;
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
    public class EspecialidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Especialidades
        public async Task<IActionResult> Index()
        {
              return View(await _context.Especialidades.ToListAsync());
        }

        // GET: Especialidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Especialidades == null)
            {
                return NotFound();
            }

            var especialidades = await _context.Especialidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidades == null)
            {
                return NotFound();
            }

            return View(especialidades);
        }

        // GET: Especialidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Especialidades especialidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidades);
        }

        // GET: Especialidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Especialidades == null)
            {
                return NotFound();
            }

            var especialidades = await _context.Especialidades.FindAsync(id);
            if (especialidades == null)
            {
                return NotFound();
            }
            return View(especialidades);
        }

        // POST: Especialidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Especialidades especialidades)
        {
            if (id != especialidades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadesExists(especialidades.Id))
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
            return View(especialidades);
        }

        // GET: Especialidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Especialidades == null)
            {
                return NotFound();
            }

            var especialidades = await _context.Especialidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidades == null)
            {
                return NotFound();
            }

            return View(especialidades);
        }

        // POST: Especialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Especialidades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Especialidades'  is null.");
            }
            var especialidades = await _context.Especialidades.FindAsync(id);
            if (especialidades != null)
            {
                _context.Especialidades.Remove(especialidades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialidadesExists(int id)
        {
          return _context.Especialidades.Any(e => e.Id == id);
        }
    }
}
