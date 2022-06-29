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
    public class UtentesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UtentesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Utentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utentes.ToListAsync());
        }

        // GET: Utentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Utentes == null)
            {
                return NotFound();
            }

            var utentes = await _context.Utentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utentes == null)
            {
                return NotFound();
            }

            return View(utentes);
        }

        // GET: Utentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumTelemovel,Email,Nome,NumUtente,NIF,DataNascimento,Sexo,Foto")] Utentes utente, IFormFile novaFoto)
        {
            if (ModelState.IsValid)
            {
                //se a foto não existe atribuir a foto 'semFoto.png' ao utente
                if (novaFoto == null)
                {
                    utente.Foto = "semFoto.png";
                }
                else //se uma novo foto tiver sido selecionada pelo utilizador
                {
                    if (!(novaFoto.ContentType == "image/jpeg" || novaFoto.ContentType == "image/png"))
                    {
                        // Mostra um erro
                        ModelState.AddModelError("", "Foto enviada não é uma imagem");
                        // Devolve controlo a view, com os dados previamente inseridos
                        return View(utente);
                    }
                    else
                    {
                        // define image name
                        Guid g = Guid.NewGuid();
                        string nomeImg = utente.NumUtente + "_GUID" + g.ToString();
                        string tipoImagem = Path.GetExtension(novaFoto.FileName).ToLower();
                        nomeImg += tipoImagem;
                        // add image name to vet data
                        utente.Foto = nomeImg;
                    }
                }
                _context.Add(utente);
                await _context.SaveChangesAsync();

                // guarda o ficheiro da imagem no disco
                if (novaFoto != null)
                {
                    // pergunta ao servidor o endereço usar
                    string addressGuardarFicheiro = _webHostEnvironment.WebRootPath;
                    string novaLocalFicheiro = Path.Combine(addressGuardarFicheiro, "Fotos//Utentes");
                    // verifica se a diretoria existe, se não existir criar
                    if (!Directory.Exists(novaLocalFicheiro))
                    {
                        Directory.CreateDirectory(novaLocalFicheiro);
                    }
                    // guarda imagem no disco
                    novaLocalFicheiro = Path.Combine(novaLocalFicheiro, utente.Foto);
                    using var stream = new FileStream(novaLocalFicheiro, FileMode.Create);
                    await novaFoto.CopyToAsync(stream);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(utente);
        }

        // GET: Utentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Utentes == null)
            {
                return NotFound();
            }

            var utente = await _context.Utentes.FindAsync(id);
            if (utente == null)
            {
                return NotFound();
            }

            HttpContext.Session.SetInt32("UtenteEditId", utente.Id);
            HttpContext.Session.SetString("FotoUtente", utente.Foto);
            return View(utente);
        }

        // POST: Utentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumTelemovel,Email,Nome,NumUtente,NIF,DataNascimento,Sexo,Foto")] Utentes utente, IFormFile novaFoto, string fotoApagar)
        {
            if (id != utente.Id)
            {
                return NotFound();
            }
            var idPrevioEdit = HttpContext.Session.GetInt32("UtenteEditId");

            //se a variavel de sessão com o id do utente a ser alterado não existe
            if (idPrevioEdit == null)
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                //retornar a view com os dados previamente dados pelo utilizador
                return View(utente);
            }

            //se id é diferente ao inicial retornar ao index
            if (idPrevioEdit != utente.Id)
            {
                return RedirectToAction("Index");
            }

            //se foto não existe atribuir a foto 'semFoto.png'
            if (novaFoto == null)
            {
                utente.Foto = "semFoto.png";
            }
            else //se uma novo foto tiver sido selecionada pelo utilizador
            {
                if (!(novaFoto.ContentType == "image/jpeg" || novaFoto.ContentType == "image/png"))
                {
                    // Mostra um erro
                    ModelState.AddModelError("", "Foto enviada não é uma imagem");
                    // Devolve controlo a view, com os dados previamente inseridos
                    return View(utente);
                }
                else
                {
                    // define image name
                    Guid g = Guid.NewGuid();
                    string nomeImg = utente.NumUtente + "_GUID" + g.ToString();
                    string tipoImagem = Path.GetExtension(novaFoto.FileName).ToLower();
                    nomeImg += tipoImagem;
                    // add image name to vet data
                    utente.Foto = nomeImg;
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utente);
                    await _context.SaveChangesAsync();
                    //Alterar Imagem--------------------------------------------------------
                    // guarda o ficheiro da imagem no disco
                    if (novaFoto != null || fotoApagar.Equals("true"))
                    {
                        // pergunta ao servidor o endereço usar
                        string addressGuardarFicheiro = _webHostEnvironment.WebRootPath;
                        string novaLocalFicheiro = Path.Combine(addressGuardarFicheiro, "Fotos//Utentes");

                        // verifica se a diretoria existe, se não existir cria
                        if (!Directory.Exists(novaLocalFicheiro))
                        {
                            Directory.CreateDirectory(novaLocalFicheiro);
                        }

                        //Apaga Foto anterior-----------------------------------------------
                        if (fotoApagar.Equals("true"))
                        {
                            string fotoAntiga = HttpContext.Session.GetString("FotoUtente");

                            if (fotoAntiga == null)
                            {
                                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                                return View(utente);
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
                        //Guarda nova Foto
                        if (novaFoto != null)
                        {
                            // guarda imagem nova no disco -------------------------------------------
                            novaLocalFicheiro = Path.Combine(novaLocalFicheiro, utente.Foto);
                            using var stream = new FileStream(novaLocalFicheiro, FileMode.Create);
                            await novaFoto.CopyToAsync(stream);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtentesExists(utente.Id))
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
            return View(utente);
        }

        // GET: Utentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Utentes == null)
            {
                return NotFound();
            }

            var utente = await _context.Utentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32("UtenteDeleteId", utente.Id);
            return View(utente);
        }

        // POST: Utentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Utentes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Utentes'  is null.");
            }
            var utentes = await _context.Utentes.FindAsync(id);
            var previoGuardado = HttpContext.Session.GetInt32("UtenteDeleteId");

            if (previoGuardado == null || (previoGuardado != id))
            {
                ModelState.AddModelError("", "Sessão Expirou, passou de tempo");
                return RedirectToAction("Index");
            }

            if (utentes != null)
            {
                // pergunta ao servidor o endereço usar
                string addressGuardarFicheiro = _webHostEnvironment.WebRootPath;
                string novaLocalFicheiro = Path.Combine(addressGuardarFicheiro, "Fotos//Utentes");

                //Apaga Foto-----------------------------------------------
                if (Directory.Exists(novaLocalFicheiro) && utentes.Foto is not null && !utentes.Foto.Equals("semFoto.png"))
                {
                    FileInfo imgAntiga = new FileInfo(Path.Combine(novaLocalFicheiro, utentes.Foto));
                    if (imgAntiga.Exists)//verifica se o ficheiro existe
                    {
                        imgAntiga.Delete();//se existir elimina
                    }
                }
                _context.Utentes.Remove(utentes);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtentesExists(int id)
        {
            return _context.Utentes.Any(e => e.Id == id);
        }
    }
}
