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
    public class MedicosAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedicosAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicosViewModel>>> GetMedicos()
        {
            return await _context.Medicos.Include(x => x.ListaEspecialidades)
                            .Select(m => new MedicosViewModel
                            {
                                Id = m.Id,
                                Nome = m.Nome,
                                NumCedulaProf = m.NumCedulaProf,
                                NumTelefone = m.NumTelefone,
                                Email = m.Email,
                                DataNascimento = m.DataNascimento.ToString("dd/MM/yyyy"),
                                Foto = m.Foto,
                                Especialidades = m.ListaEspecialidades
                            }).ToListAsync();
        }

        // GET: api/MedicosAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicosViewModel>> GetMedicos(int id)
        {
            var medicos = await _context.Medicos.Select(m => new MedicosViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                NumCedulaProf = m.NumCedulaProf,
                NumTelefone = m.NumTelefone,
                Email = m.Email,
                DataNascimento = m.DataNascimento.ToString("dd/MM/yyyys"),
                Foto = m.Foto,
            }).Where(a => a.Id == id).FirstOrDefaultAsync();

            if (medicos == null)
            {
                return NotFound();
            }

            return medicos;
        }

        // PUT: api/MedicosAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicos(int id, Medicos medicos)
        {
            if (id != medicos.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicosExists(id))
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

        // POST: api/MedicosAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicos>> PostMedicos(Medicos medicos)
        {
            _context.Medicos.Add(medicos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicos", new { id = medicos.Id }, medicos);
        }

        // DELETE: api/MedicosAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicos(int id)
        {
            var medicos = await _context.Medicos.FindAsync(id);
            if (medicos == null)
            {
                return NotFound();
            }

            _context.Medicos.Remove(medicos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicosExists(int id)
        {
            return _context.Medicos.Any(e => e.Id == id);
        }
    }
}
