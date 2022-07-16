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
    public class PagamentosAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PagamentosAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PagamentosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagamentoViewModel>>> GetPagamentos()
        {
            return await _context.Pagamentos.Select(p => new PagamentoViewModel
            {
                Id = p.Id,
                Valor = p.Valor + "€",
                Estado = p.Estado ? "Pago" : "Aguarda Pagamento",
                Descricao = p.Descricao,
                DataEfetuado = p.DataEfetuado.HasValue ? p.DataEfetuado.Value.ToString("dd/MM/yyyy") : string.Empty,
                Metodo = p.Metodo,
                Consulta = p.Consulta.Medico.NumCedulaProf + " " + p.Consulta.Data.ToString("dd/MM/yyyy")
            }).OrderBy(p => p.Estado).ToListAsync();
        }

        // GET: api/PagamentosAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PagamentoViewModel>> GetPagamentos(int id)
        {
            var pagamentos = await _context.Pagamentos.Select(p => new PagamentoViewModel
            {
                Id = p.Id,
                Valor = p.Valor + "€",
                Estado = p.Estado ? "Pago" : "Aguarda Pagamento",
                Descricao = p.Descricao,
                DataEfetuado = p.DataEfetuado.HasValue ? p.DataEfetuado.Value.ToString("dd/MM/yyyy") : string.Empty,
                Metodo = p.Metodo,
                Consulta = p.Consulta.Medico.NumCedulaProf + " " + p.Consulta.Data.ToString("dd/MM/yyyy hh:yyyy")
            })
                .Where(a => a.Id == id)
                                .FirstOrDefaultAsync();

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
        public async Task<ActionResult<Pagamentos>> PostPagamentos([FromForm] Pagamentos pagamentos)
        {
            Pagamentos backup = pagamentos;
            try
            {
                pagamentos.Valor = Convert.ToDecimal(pagamentos.AuxValor.Replace('.', ','));
                //o facto de o pagamaento estar efetuado define se necessita ou não necessita dos campos DataEfetuado e Metodoo
                if (!(pagamentos.Estado && (pagamentos.DataEfetuado is null || pagamentos.Metodo is null) ||
                     !pagamentos.Estado && (pagamentos.DataEfetuado is not null || pagamentos.Metodo is not null))
                )
                {
                    _context.Pagamentos.Add(pagamentos);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                throw;
            }
            backup.Id = pagamentos.Id;
            return CreatedAtAction("GetPagamentos", new { id = pagamentos.Id }, pagamentos);
        }

        // DELETE: api/PagamentosAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamentos(int id)
        {
            try
            {
                var pagamentos = await _context.Pagamentos.FindAsync(id);
                if (pagamentos == null)
                {
                    return NotFound();
                }

                _context.Pagamentos.Remove(pagamentos);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return NoContent();
        }

        private bool PagamentosExists(int id)
        {
            return _context.Pagamentos.Any(e => e.Id == id);
        }
    }
}
