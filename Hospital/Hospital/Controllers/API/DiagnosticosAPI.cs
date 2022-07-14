using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;
using Hospital.Models.APIViewModels;

namespace Hospital.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticosAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DiagnosticosAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DiagnosticosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagnosticosViewModel>>> GetDiagnosticos()
        {
            return await _context.Diagnosticos.Include(x => x.ListaConsultas).ThenInclude(x => x.Utente)
                .Select(d => new DiagnosticosViewModel
                {
                    Id = d.Id,
                    Label = d.Titulo + "(Utente: " + d.ListaConsultas.Select(u => u.Utente.NumUtente).First() + ")",
                    Titulo = d.Titulo,
                    Estado = d.Estado,
                    Descricao = d.Descricao,
                    Utente = d.ListaConsultas.Select(u => u.Utente.Nome + "(Utente: " + u.Utente.NumUtente + ")").First()
                }).ToListAsync();
        }

        // GET: api/DiagnosticosAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiagnosticosViewModel>> GetDiagnosticos(int id)
        {
            var diagnosticos = await _context.Diagnosticos.Include(x => x.ListaConsultas).ThenInclude(x => x.Utente)
                .Select(d => new DiagnosticosViewModel
                {
                    Id = d.Id,
                    Label = d.Titulo + "(Utente: " + d.ListaConsultas.Select(u => u.Utente.NumUtente).First() + ")",
                    Titulo = d.Titulo,
                    Estado = d.Estado,
                    Descricao = d.Descricao,
                    Utente = d.ListaConsultas.Select(u => u.Utente.Nome + "(Utente: " + u.Utente.NumUtente + ")").First()
                })
                .Where(a => a.Id == id).FirstOrDefaultAsync();

            if (diagnosticos == null)
            {
                return NotFound();
            }

            return diagnosticos;
        }

        // PUT: api/DiagnosticosAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnosticos(int id, Diagnosticos diagnosticos)
        {
            if (id != diagnosticos.Id)
            {
                return BadRequest();
            }

            _context.Entry(diagnosticos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosticosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DiagnosticosAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diagnosticos>> PostDiagnosticos(Diagnosticos diagnosticos)
        {
            int numUtentes = diagnosticos.ListaConsultas.Select(u => u.Utente.Id).Distinct().Count();
            if (numUtentes != 1)
            {
                return BadRequest();
            }
            _context.Diagnosticos.Add(diagnosticos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiagnosticos", new { id = diagnosticos.Id }, diagnosticos);
        }

        // DELETE: api/DiagnosticosAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnosticos(int id)
        {
            var diagnosticos = await _context.Diagnosticos.FindAsync(id);
            if (diagnosticos == null)
            {
                return NotFound();
            }

            _context.Diagnosticos.Remove(diagnosticos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiagnosticosExists(int id)
        {
            return _context.Diagnosticos.Any(e => e.Id == id);
        }
    }
}
