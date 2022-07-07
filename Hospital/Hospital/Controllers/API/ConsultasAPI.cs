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
    public class ConsultasAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConsultasAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ConsultasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultasViewModel>>> GetConsultas()
        {
            return await _context.Consultas.Include(c => c.Diagnostico).Select(m => new ConsultasViewModel
            {
                Id = m.Id,
                Data = m.Data.ToString("dd/MM/yyyy HH:mm"),
                Estado = EstadoConsulta(m.Estado),
                Motivo = m.Motivo,
                Utente = m.Utente.Nome + " (Utente: " + m.Utente.NumUtente + ")" ,
                Medico = m.Medico.Nome + " (Cédula: " + m.Medico.NumCedulaProf + ")",
                Diagnostico = m.Diagnostico.Titulo 
            }).ToListAsync();
        }

        // GET: api/ConsultasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultasViewModel>> GetConsultas(int id)
        {
            var consultas = await _context.Consultas.Include(c => c.Diagnostico).Select(m => new ConsultasViewModel
            {
                Id = m.Id,
                Data = m.Data.ToString("dd/MM/yyyy HH:mm"),
                Estado = EstadoConsulta(m.Estado),
                Motivo = m.Motivo,
                Utente = m.Utente.Nome + " (Utente: " + m.Utente.NumUtente + ")",
                Medico = m.Medico.Nome + " (Cédula: " + m.Medico.NumCedulaProf + ")",
                Diagnostico = m.Diagnostico.Titulo
            }).Where(a => a.Id == id).FirstOrDefaultAsync(); ;

            if (consultas == null)
            {
                return NotFound();
            }

            return consultas;
        }

        // PUT: api/ConsultasAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultas(int id, Consultas consultas)
        {
            if (id != consultas.Id)
            {
                return BadRequest();
            }

            _context.Entry(consultas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultasExists(id))
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

        // POST: api/ConsultasAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consultas>> PostConsultas(Consultas consultas)
        {
            _context.Consultas.Add(consultas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultas", new { id = consultas.Id }, consultas);
        }

        // DELETE: api/ConsultasAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultas(int id)
        {
            var consultas = await _context.Consultas.FindAsync(id);
            if (consultas == null)
            {
                return NotFound();
            }

            _context.Consultas.Remove(consultas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultasExists(int id)
        {
            return _context.Consultas.Any(e => e.Id == id);
        }

        private static string EstadoConsulta(string estado)
        {
            switch (estado.ToUpper())
            {
                case "P":
                    return "Pendente";
                case "M":
                    return "Marcada";
                case "F":
                    return "Finalizada";
                case "C":
                    return "Cancelada";
                default:
                    return "Desconhecido";
            }
            return "Desconhecido";
        }
    }
}
