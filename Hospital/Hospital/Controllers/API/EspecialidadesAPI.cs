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
    public class EspecialidadesAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadesAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EspecialidadesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadesViewModel>>> GetEspecialidades()
        {

            return await _context.Especialidades.Include(x => x.ListaMedicos)
                .Select(e => new EspecialidadesViewModel
                {
                    Id = e.Id,
                    Nome = e.Nome,
                    Medicos = e.ListaMedicos
                }).ToListAsync();
        }

        // GET: api/EspecialidadesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EspecialidadesViewModel>> GetEspecialidades(int id)
        {
            var especialidades = await _context.Especialidades.
                                Select(a => new EspecialidadesViewModel
                                {
                                    Id = a.Id,
                                    Nome = a.Nome,
                                    Medicos = a.ListaMedicos
                                }).Where(a => a.Id == id)
                                .FirstOrDefaultAsync();
            if (especialidades == null)
            {
                return NotFound();
            }

            return especialidades;
        }

        // PUT: api/EspecialidadesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidades(int id, Especialidades especialidades)
        {
            if (id != especialidades.Id)
            {
                return BadRequest();
            }

            _context.Entry(especialidades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadesExists(id))
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

        // POST: api/EspecialidadesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Especialidades>> PostEspecialidades([FromForm] Especialidades especialidades, [FromForm] string[] medicosId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(especialidades);
                    //converte os id de string para int
                    int[] medicoIdInt = Array.ConvertAll(medicosId, i => int.Parse(i));
                    foreach (int medicoId in medicoIdInt)
                    {
                        var medico = _context.Medicos
                                    .Include(p => p.ListaEspecialidades)
                                    .Single(p => p.Id == medicoId);
                        medico.ListaEspecialidades.Add(especialidades);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEspecialidades", new { id = especialidades.Id }, especialidades);
        }

        // DELETE: api/EspecialidadesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidades(int id)
        {
            var especialidades = await _context.Especialidades.FindAsync(id);
            if (especialidades == null)
            {
                return NotFound();
            }

            _context.Especialidades.Remove(especialidades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialidadesExists(int id)
        {
            return _context.Especialidades.Any(e => e.Id == id);
        }
    }
}
