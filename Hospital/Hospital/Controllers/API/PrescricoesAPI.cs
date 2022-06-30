using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;

namespace Hospital.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescricoesAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PrescricoesAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PrescricoesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescricoes>>> GetPrescricoes()
        {
            return await _context.Prescricoes.ToListAsync();
        }

        // GET: api/PrescricoesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prescricoes>> GetPrescricoes(int id)
        {
            var prescricoes = await _context.Prescricoes.FindAsync(id);

            if (prescricoes == null)
            {
                return NotFound();
            }

            return prescricoes;
        }

        // PUT: api/PrescricoesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescricoes(int id, Prescricoes prescricoes)
        {
            if (id != prescricoes.Id)
            {
                return BadRequest();
            }

            _context.Entry(prescricoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescricoesExists(id))
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

        // POST: api/PrescricoesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prescricoes>> PostPrescricoes(Prescricoes prescricoes)
        {
            _context.Prescricoes.Add(prescricoes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescricoes", new { id = prescricoes.Id }, prescricoes);
        }

        // DELETE: api/PrescricoesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescricoes(int id)
        {
            var prescricoes = await _context.Prescricoes.FindAsync(id);
            if (prescricoes == null)
            {
                return NotFound();
            }

            _context.Prescricoes.Remove(prescricoes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrescricoesExists(int id)
        {
            return _context.Prescricoes.Any(e => e.Id == id);
        }
    }
}
