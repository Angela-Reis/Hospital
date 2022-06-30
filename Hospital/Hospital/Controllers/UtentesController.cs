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
    [Authorize(Roles = "Administrativo, Medico, Utente")]
    public class UtentesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<UtilizadorApp> _userManager;


        public UtentesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, UserManager<UtilizadorApp> userManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        // GET: Utentes
        public async Task<IActionResult> Index()
        {
            List<Utentes> utentes = null;
            // obtem o id do utilizador
            string utilID = _userManager.GetUserId(User);
            //Redireciona os Utentes para a sua pagina de Detalhes
            if (User.IsInRole("Utente"))
            {
                var utente = await _context.Utentes.Where(u => u.IdUtilizador == utilID).FirstOrDefaultAsync();
                return RedirectToAction("Details", new { id = utente.Id });
            }
            else if (User.IsInRole("Medico"))
            {
                //mostrar apenas utentes com que o médico já teve consultas
                utentes = await _context.Utentes.Where(u => u.ListaConsultas.Any(l => l.Medico.IdUtilizador == utilID)).ToListAsync();
            }
            else
            {
                utentes = await _context.Utentes.ToListAsync();
            }


            return View(utentes);
        }

        // GET: Utentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Utentes == null)
            {
                return NotFound();
            }

            Utentes utente = null;
            string utilID = _userManager.GetUserId(User);
            if (User.IsInRole("Utente"))
            {

                utente = await _context.Utentes.Where(u => u.IdUtilizador == utilID).FirstOrDefaultAsync(m => m.Id == id);

            }
            else if (User.IsInRole("Medico"))
            {
                utente = await _context.Utentes
                    .Where(u => u.ListaConsultas.Any(l => l.Medico.IdUtilizador == utilID))
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            else
            {
                utente = await _context.Utentes.FirstOrDefaultAsync(m => m.Id == id); ;
            }


            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }
        /* Os Utentes são criados com o Registro
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
                [Authorize(Roles = "Administrativo")]
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
                }*/

        // GET: Utentes/Edit/5
        [Authorize(Roles = "Administrativo, Utente")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Utentes == null)
            {
                return NotFound();
            }
            // obtem o id do utilizador
            Utentes utente = null;
            if (User.IsInRole("Utente"))
            {
                string utilID = _userManager.GetUserId(User);
                utente = await _context.Utentes.Where(u => u.IdUtilizador == utilID).FirstOrDefaultAsync(u => u.Id == id);
            }
            else if (User.IsInRole("Administrativo"))
            {

                utente = await _context.Utentes.FindAsync(id);
            }

            if (utente == null)
            {
                return NotFound();
            }

            HttpContext.Session.SetInt32("UtenteEditId", utente.Id);
            HttpContext.Session.SetString("UtenteIdUtilizador", utente.IdUtilizador);
            HttpContext.Session.SetString("FotoUtente", utente.Foto);
            return View(utente);
        }

        // POST: Utentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo, Utente")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumTelemovel,Email,Nome,NumUtente,NIF,DataNascimento,Sexo,Foto")] Utentes utente, IFormFile novaFoto, string fotoApagar)
        {
            if (id != utente.Id)
            {
                return NotFound();
            }
            var idPrevioEdit = HttpContext.Session.GetInt32("UtenteEditId");
            var fotoAntiga = HttpContext.Session.GetString("FotoUtente");
            //colocar o IdUtilizador correto
            var utenteIdUtilizador = HttpContext.Session.GetString("UtenteIdUtilizador");
            utente.IdUtilizador = utenteIdUtilizador;
            //se a variavel de sessão com o id do utente a ser alterado não existe
            if (idPrevioEdit == null || fotoAntiga == null || utenteIdUtilizador==null)
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
        [Authorize(Roles = "Administrativo")]
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
        [Authorize(Roles = "Administrativo")]
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
