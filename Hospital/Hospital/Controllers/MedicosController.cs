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
    public class MedicosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MedicosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Medicos
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //passar para o index a lista de Especialidades
            return View(await _context.Medicos.Include(x => x.ListaEspecialidades).ToListAsync());
        }

        // GET: Medicos/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medicos = await _context.Medicos.Include(m => m.ListaEspecialidades)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicos == null)
            {
                return NotFound();
            }

            return View(medicos);
        }

        // GET: Medicos/Create
        public IActionResult Create()
        {
            ViewData["ListaEspecialidades"] = new MultiSelectList(_context.Especialidades, nameof(Especialidades.Id), nameof(Especialidades.Nome));
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumTelefone,Email,Nome,NumCedulaProf,DataNascimento,Foto")] Medicos medicos, int[] EspecialidadeId, IFormFile novaFotoMed)
        {
            if (novaFotoMed == null)
            {
                medicos.Foto = "semFoto.png";
            }
            else
            {
                //verificar se o ficheiro recebudo é uma imagem
                if (!(novaFotoMed.ContentType == "image/jpeg" || novaFotoMed.ContentType == "image/png"))
                {
                    // Mostra um erro
                    ModelState.AddModelError("", "Foto enviada não é uma imagem");
                    // Devolve controlo a view, com os dados previamente inseridos
                    return View(medicos);
                }
                else
                {
                    // define image name
                    Guid g = Guid.NewGuid();
                    string nomeImg = medicos.NumCedulaProf + "_GUID" + g.ToString();
                    string tipoImagem = Path.GetExtension(novaFotoMed.FileName).ToLower();
                    nomeImg += tipoImagem;
                    // add image name to vet data
                    medicos.Foto = nomeImg;
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(medicos);
                foreach (int especId in EspecialidadeId)
                {
                    var espicialidade = await _context.Especialidades.Include(e => e.ListaMedicos).SingleAsync(e => e.Id == especId);
                    espicialidade.ListaMedicos.Add(medicos);
                }
                await _context.SaveChangesAsync();

                // guarda o ficheiro da imagem no disco
                if (novaFotoMed != null)
                {
                    // pergunta ao servidor o endereço usar
                    string addressGuardarFicheiro = _webHostEnvironment.WebRootPath;
                    string novaLocalFicheiro = Path.Combine(addressGuardarFicheiro, "Fotos//Medicos");
                    // verifica se a diretoria existe
                    if (!Directory.Exists(novaLocalFicheiro))
                    {
                        Directory.CreateDirectory(novaLocalFicheiro);
                    }
                    // guarda imagem no disco
                    novaLocalFicheiro = Path.Combine(novaLocalFicheiro, medicos.Foto);
                    using var stream = new FileStream(novaLocalFicheiro, FileMode.Create);
                    await novaFotoMed.CopyToAsync(stream);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(medicos);
        }

        // GET: Medicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medicos = await _context.Medicos.Include(m => m.ListaEspecialidades).FirstOrDefaultAsync(m => m.Id == id);
            if (medicos == null)
            {
                return NotFound();
            }


            //devolve todos os medicos que já pertencem à especialidade
            var selecionados = medicos.ListaEspecialidades.Select(x => x.Id).ToArray();
            ViewData["ListaEspecialidades"] = new MultiSelectList(_context.Especialidades, nameof(Especialidades.Id), nameof(Especialidades.Nome), selecionados);

            HttpContext.Session.SetInt32("MedicoEditId", medicos.Id);
            HttpContext.Session.SetString("FotoMedico", medicos.Foto);
            return View(medicos);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumTelefone,Email,Nome,NumCedulaProf,DataNascimento,Foto")] Medicos medicos, int[] EspecialidadeId, IFormFile novaFotoMed, string FotoApagar)
        {
            if (id != medicos.Id)
            {
                return NotFound();
            }
            var medicoPrevioGuardado = HttpContext.Session.GetInt32("MedicoEditId");

            if (medicoPrevioGuardado == null)
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return View(medicos);
            }

            if (medicoPrevioGuardado != medicos.Id)
            {
                return RedirectToAction("Index");
            }

            if (novaFotoMed == null)
            {
                medicos.Foto = "semFoto.png";
            }
            else
            {
                if (!(novaFotoMed.ContentType == "image/jpeg" || novaFotoMed.ContentType == "image/png"))
                {
                    // Mostra um erro
                    ModelState.AddModelError("", "Foto enviada não é uma imagem");
                    // Devolve controlo a view, com os dados previamente inseridos
                    return View(medicos);
                }
                else
                {
                    // define image name
                    Guid g = Guid.NewGuid();
                    string nomeImg = medicos.NumCedulaProf + "_GUID" + g.ToString();
                    string tipoImagem = Path.GetExtension(novaFotoMed.FileName).ToLower();
                    nomeImg += tipoImagem;
                    // add image name to vet data
                    medicos.Foto = nomeImg;
                }
            }
            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(medicos);
                    var tempmedicos = await _context.Medicos.Include(m => m.ListaEspecialidades).FirstOrDefaultAsync(m => m.Id == id);

                    //Alterar Especialidades-----------------------------------------------------------------------
                    if (tempmedicos != null)
                    {
                        //remover especialidades------------------------------------------
                        //verificar que id existentes anteriormente não existem nos novos id selecionados
                        var removerMedicos = tempmedicos.ListaEspecialidades.Where(e => !EspecialidadeId.Contains(e.Id)).Select(e => e.Id).ToList();
                        foreach (var remover in removerMedicos)
                        {
                            tempmedicos.ListaEspecialidades.Remove(tempmedicos.ListaEspecialidades.Single(x => x.Id == remover));
                        }
                        //adicionar especialidades ------------------------------------
                        //verificar que id novos não existem nos id previos
                        var lista = tempmedicos.ListaEspecialidades.Select(le => le.Id).ToList();
                        var adicionarMedicos = EspecialidadeId.Where(e => !lista.Contains(e)).ToList();
                        foreach (var adicionar in adicionarMedicos)
                        {
                            tempmedicos.ListaEspecialidades.Add(_context.Especialidades.Single(p => p.Id == adicionar));
                        }
                    }
                    //Alterar Imagem--------------------------------------------------------
                    // guarda o ficheiro da imagem no disco
                    if (novaFotoMed != null || FotoApagar.Equals("true"))
                    {
                        // pergunta ao servidor o endereço usar
                        string addressGuardarFicheiro = _webHostEnvironment.WebRootPath;
                        string novaLocalFicheiro = Path.Combine(addressGuardarFicheiro, "Fotos//Medicos");

                        // verifica se a diretoria existe, se não existir cria
                        if (!Directory.Exists(novaLocalFicheiro))
                        {
                            Directory.CreateDirectory(novaLocalFicheiro);
                        }

                        //Apaga Foto anterior-----------------------------------------------
                        if (FotoApagar.Equals("true"))
                        {
                            string fotoAntiga = HttpContext.Session.GetString("FotoMedico");

                            if (fotoAntiga == null)
                            {
                                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                                return View(medicos);
                            }
                            if (!fotoAntiga.Equals("semFoto.png"))
                            {
                                FileInfo imgAntiga = new FileInfo(Path.Combine(novaLocalFicheiro, fotoAntiga));
                                if (imgAntiga.Exists)//verifica se o ficheiro existe
                                {
                                    imgAntiga.Delete();//se existir elimina
                                }
                            }
                        }
                        if (novaFotoMed != null)
                        {
                            // guarda imagem nova no disco -------------------------------------------
                            novaLocalFicheiro = Path.Combine(novaLocalFicheiro, medicos.Foto);
                            using var stream = new FileStream(novaLocalFicheiro, FileMode.Create);
                            await novaFotoMed.CopyToAsync(stream);
                        }
                    }
                    medicos = tempmedicos;
                    _context.Update(medicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicosExists(medicos.Id))
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
            return View(medicos);
        }

        // GET: Medicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicos == null)
            {
                return NotFound();
            }

            var medicos = await _context.Medicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicos == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32("MedicoDeleteId", medicos.Id);

            return View(medicos);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Medicos'  is null.");
            }
            var medicoPrevioGuardado = HttpContext.Session.GetInt32("MedicoDeleteId");

            if (medicoPrevioGuardado == null || (medicoPrevioGuardado != id))
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return RedirectToAction("Index");
            }

            var medicos = await _context.Medicos.FindAsync(id);
            if (medicos != null)
            {
                // pergunta ao servidor o endereço usar
                string addressGuardarFicheiro = _webHostEnvironment.WebRootPath;
                string novaLocalFicheiro = Path.Combine(addressGuardarFicheiro, "Fotos//Medicos");

                //Apaga Foto-----------------------------------------------
                if (Directory.Exists(novaLocalFicheiro) && !medicos.Foto.Equals("semFoto.png"))
                {
                    FileInfo imgAntiga = new FileInfo(Path.Combine(novaLocalFicheiro, medicos.Foto));
                    if (imgAntiga.Exists)//verifica se o ficheiro existe
                    {
                        imgAntiga.Delete();//se existir elimina
                    }
                }
                
                _context.Medicos.Remove(medicos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicosExists(int id)
        {
            return _context.Medicos.Any(e => e.Id == id);
        }

        //Verifica se a cedula profisional já existe
        public JsonResult CedulaNaoDuplicada(string NumCedulaProf, int Id)
        {
            try
            {
                var existe = _context.Medicos.Any(x => x.NumCedulaProf == NumCedulaProf && x.Id != Id);
                return Json(!existe);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
    }
}
