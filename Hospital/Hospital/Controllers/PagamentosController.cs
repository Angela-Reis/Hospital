using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Hospital.Controllers
{
    [Authorize]
    [Authorize(Roles = "Administrativo, Utente")]
    public class PagamentosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UtilizadorApp> _userManager;

        public PagamentosController(ApplicationDbContext context, UserManager<UtilizadorApp> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Pagamentos
        public async Task<IActionResult> Index()
        {
            List<Pagamentos> pagamentos = null;
            // obtem o id do utilizador
            string utilID = _userManager.GetUserId(User);
            //Redireciona os Utentes para a sua pagina de Detalhes
            if (User.IsInRole("Utente"))
            {
                //moatrar apenas diagnósticos do proprio utente
                pagamentos = await _context.Pagamentos
                    .Include(p => p.Consulta).ThenInclude(m=> m.Medico)
                    .Where(p=>p.Consulta.Utente.IdUtilizador == utilID)
                    .ToListAsync();
            }
            else
            {
                pagamentos = await _context.Pagamentos.Include(p => p.Consulta).ThenInclude(m => m.Medico).ToListAsync();
            }
            return View(pagamentos);
        }

        // GET: Pagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }
            Pagamentos pagamento = null;
            // obtem o id do utilizador
            string utilID = _userManager.GetUserId(User);
            if (User.IsInRole("Utente"))
            {
                //moatrar apenas diagnósticos do proprio utente
                pagamento = await _context.Pagamentos
                    .Include(p => p.Consulta)
                    .Where(p => p.Consulta.Utente.IdUtilizador == utilID)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                pagamento = await _context.Pagamentos.Include(p => p.Consulta).FirstOrDefaultAsync(m => m.Id == id);
            }

            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamentos/Create
        [Authorize(Roles = "Administrativo")]
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
        public async Task<IActionResult> Create([Bind("Id,AuxValor,Valor,Descricao,Estado,DataEfetuado,Metodo,ConsultaFK")] Pagamentos pagamentos)
        {
            // transferir os dados de AuxValor para valor
            pagamentos.Valor = Convert.ToDecimal(pagamentos.AuxValor.Replace('.', ','));
            //se o modelo for valido,  no entanto, o estado de pagamento
            //ou estiver efetuado sem a data e método
            //ou não estiver efetuado, no entanto, ter data ou método
            //os dados não estão corretos
            if (ModelState.IsValid &&
                !(  pagamentos.Estado && (pagamentos.DataEfetuado is null || pagamentos.Metodo is null) ||
                    !pagamentos.Estado && (pagamentos.DataEfetuado is not null || pagamentos.Metodo is not null)
                )
            )
            {
                _context.Add(pagamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultaFK"] = new SelectList(_context.Consultas, "Id", "Motivo", pagamentos.ConsultaFK);
            return View(pagamentos);
        }

        // GET: Pagamentos/Edit/5
        [Authorize(Roles = "Administrativo")]
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
            pagamentos.AuxValor = pagamentos.Valor.ToString();
            ViewData["ConsultaFK"] = new SelectList(_context.Consultas, "Id", "Motivo", pagamentos.ConsultaFK);
            //variavel de sessão que guarda o id da consulta a ser editada
            HttpContext.Session.SetInt32("PagamentosEditId", pagamentos.Id);
            return View(pagamentos);
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AuxValor,Valor,Descricao,Estado,DataEfetuado,Metodo,ConsultaFK")] Pagamentos pagamentos)
        {
            if (id != pagamentos.Id)
            {
                return NotFound();
            }

            //verifica se o id previamente guardado é igual ao devolvido após as mudanças
            var previoGuardada = HttpContext.Session.GetInt32("PagamentosEditId");

            if (previoGuardada == null)
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return View(pagamentos);
            }

            if (previoGuardada != pagamentos.Id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                // transferir os dados de AuxValor para valor
                pagamentos.Valor = Convert.ToDecimal(pagamentos.AuxValor.Replace('.', ','));
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
        [Authorize(Roles = "Administrativo")]
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
            //variavel de sessão que guarda o id da consulta a ser editada
            HttpContext.Session.SetInt32("PagamentosEditId", pagamentos.Id);
            return View(pagamentos);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagamentos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pagamentos'  is null.");
            }
            //verifica se o id previamente guardado é igual ao devolvido
            var previoGuardada = HttpContext.Session.GetInt32("PagamentosEditId");


            var pagamentos = await _context.Pagamentos.FindAsync(id);
            if (previoGuardada == null)
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return View(pagamentos);
            }

            if (previoGuardada != id)
            {
                return RedirectToAction("Index");
            }

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
