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
    public class PagamentosAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PagamentosAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PagamentosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamentos>>> GetPagamentos()
        {
            return await _context.Pagamentos.ToListAsync();
        }

        // GET: api/PagamentosAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamentos>> GetPagamentos(int id)
        {
            var pagamentos = await _context.Pagamentos.FindAsync(id);

            if (pagamentos == null)
            {
                return NotFound();
            }

            return pagamentos;
        }

        // PUT: api/PagamentosAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamentos(int id, Pagamentos pagamentos)
        {
            if (id != pagamentos.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagamentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentosExists(id))
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

        // POST: api/PagamentosAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pagamentos>> PostPagamentos(Pagamentos pagamentos)
        {
            _context.Pagamentos.Add(pagamentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagamentos", new { id = pagamentos.Id }, pagamentos);
        }

        // DELETE: api/PagamentosAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamentos(int id)
        {
            var pagamentos = await _context.Pagamentos.FindAsync(id);
            if (pagamentos == null)
            {
                return NotFound();
            }

            _context.Pagamentos.Remove(pagamentos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagamentosExists(int id)
        {
            return _context.Pagamentos.Any(e => e.Id == id);
        }
    }
}
