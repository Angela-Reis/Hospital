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

namespace Hospital.Controllers
{
    [Authorize]
    public class EspecialidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Especialidades
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //incluir a lista de Medicos
            return View(await _context.Especialidades.Include(x => x.ListaMedicos).ToListAsync());
        }

        // GET: Especialidades/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Especialidades == null)
            {
                return NotFound();
            }
            //devolve, se existir, a especialidade com o id selecionado, incluindo a lista de medicos que pertecem a esta especialidade
            var especialidades = await _context.Especialidades.Include(x => x.ListaMedicos).FirstOrDefaultAsync(m => m.Id == id);

            if (especialidades == null)
            {
                return NotFound();
            }

            return View(especialidades);
        }

        // GET: Especialidades/Create
        public IActionResult Create()
        {
            var lista = _context.Medicos.Select(m => new
            {
                m.Id,
                Nome = m.NumCedulaProf + " - " + m.Nome
            }).ToList();
            ViewData["ListaMedicos"] = new MultiSelectList(lista, nameof(Medicos.Id), nameof(Medicos.Nome));
            return View();
        }

        // POST: Especialidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,MedicosId")] Especialidades especialidades, int[] MedicosId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidades);
                foreach (int medicoId in MedicosId)
                {
                    var medico = _context.Medicos
                    .Include(p => p.ListaEspecialidades)
                    .Single(p => p.Id == medicoId);
                    medico.ListaEspecialidades.Add(especialidades);
                }
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
            //procura a especialidade pelo id e inclui a lista
            var especialidades = await _context.Especialidades.Include(e => e.ListaMedicos).FirstOrDefaultAsync(i => i.Id == id); ;
            if (especialidades == null)
            {
                return NotFound();
            }

            //lista dos ids e nomes de todos os medicos 
            var lista = _context.Medicos.Select(m => new
            {
                m.Id,
                Nome = m.NumCedulaProf + " - " + m.Nome
            }).ToList();

            //devolve todos os medicos que já pertencem à especialidade
            var selecionados = especialidades.ListaMedicos.Select(x => x.Id).ToArray();
            ViewData["ListaMedicos"] = new MultiSelectList(lista, nameof(Medicos.Id), nameof(Medicos.Nome), selecionados);

            //guardar o id da especialidade a ser editada numa variavel de sessão
            HttpContext.Session.SetInt32("EspeId", especialidades.Id);

            return View(especialidades);
        }

        // POST: Especialidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,MedicosId")] Especialidades especialidades, int[] MedicosId)
        {
            if (id != especialidades.Id)
            {
                return NotFound();
            }
        
            var espPrevioGuardada = HttpContext.Session.GetInt32("EspeId");
            //verificar se o id é igual ao guardado anteriormente
            if (espPrevioGuardada == null)
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return View(especialidades);
            }

            if (espPrevioGuardada != especialidades.Id)
            {
                return RedirectToAction("Index");
            }

            //guardar o nome novo 
            string nomeNovo = especialidades.Nome;
            //pedir os dados anteriores
            especialidades = await _context.Especialidades.Include(e => e.ListaMedicos).FirstOrDefaultAsync(i => i.Id == id);
            especialidades.Nome = nomeNovo;
            if (ModelState.IsValid)
            {
                try
                {
                    //Especialidade anteriormente
                    if (especialidades != null)
                    {
                        //remover medicos------------------------------------------
                        //verificar que id existentes anteriormente não existem nos novos id selecionados
                        var removerMedicos = especialidades.ListaMedicos.Where(m => !MedicosId.Contains(m.Id)).Select(m => m.Id).ToList();
                        foreach (var remover in removerMedicos)
                        {
                            especialidades.ListaMedicos.Remove(especialidades.ListaMedicos.Single(x => x.Id == remover));
                        }
                        //adicionar medicos ------------------------------------
                        //verificar que id novos não existem nos id previos
                        var lista = especialidades.ListaMedicos.Select(lm => lm.Id).ToList();
                        var adicionarMedicos = MedicosId.Where(m => !lista.Contains(m)).ToList();
                        foreach (var adicionar in adicionarMedicos)
                        {
                            especialidades.ListaMedicos.Add(_context.Medicos.Single(p => p.Id == adicionar));
                        }
                    }
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

            var especialidades = await _context.Especialidades.Include(x => x.ListaMedicos)
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
