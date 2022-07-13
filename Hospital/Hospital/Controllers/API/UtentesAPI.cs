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
    public class UtentesAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public UtentesAPI(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/UtentesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UtentesViewModel>>> GetUtentes()
        {
            return await _context.Utentes.Select(m => new UtentesViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                NumUtente = m.NumUtente,
                NIF = m.NIF,
                NumTelefone = m.NumTelemovel,
                Email = m.Email,
                DataNascimento = m.DataNascimento.ToString("dd/MM/yyyy"),
                Sexo = m.Sexo.ToUpper().Equals("F") ? "Mulher" : "Homem",
                Foto = m.Foto
            }).ToListAsync();
            
            }

        // GET: api/UtentesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UtentesViewModel>> GetUtentes(int id)
        {
            var utentes = await _context.Utentes.Select(m => new UtentesViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                NumUtente = m.NumUtente,
                NIF = m.NIF,
                NumTelefone = m.NumTelemovel,
                Email = m.Email,
                DataNascimento = m.DataNascimento.ToString("dd/MM/yyyy"),
                Sexo = m.Sexo.ToUpper().Equals("F") ? "Mulher" : "Homem",
                Foto = m.Foto
            }).Where(a => a.Id == id).FirstOrDefaultAsync();

            if (utentes == null)
            {
                return NotFound();
            }

            return utentes;
        }

        // PUT: api/UtentesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtentes(int id, Utentes utentes)
        {
            if (id != utentes.Id)
            {
                return BadRequest();
            }

            _context.Entry(utentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtentesExists(id))
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

        // POST: api/UtentesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utentes>> PostUtentes([FromForm] Utentes utente, IFormFile novaFoto)
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
                        return BadRequest();
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

                return CreatedAtAction("GetUtentes", new { id = utente.Id }, utente);
            }
            return BadRequest();

        }

        // DELETE: api/UtentesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtentes(int id)
        {
            var utente = await _context.Utentes.FindAsync(id);
            if (utente == null)
            {
                return NotFound();
            }
            // pergunta ao servidor o endereço usar
            string adressoApp = _webHostEnvironment.WebRootPath;
            string localFicheiro = Path.Combine(adressoApp, "Fotos//Medicos");

            //Apaga Foto-----------------------------------------------
            if (Directory.Exists(localFicheiro) && !utente.Foto.Equals("semFoto.png"))
            {
                FileInfo imgAntiga = new FileInfo(Path.Combine(localFicheiro, utente.Foto));
                if (imgAntiga.Exists)//verifica se o ficheiro existe
                {
                    imgAntiga.Delete();//se existir elimina
                }
            }
            _context.Utentes.Remove(utente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtentesExists(int id)
        {
            return _context.Utentes.Any(e => e.Id == id);
        }
    }
}
