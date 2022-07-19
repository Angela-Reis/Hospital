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
    public class MedicosAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MedicosAPI(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/MedicosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicosViewModel>>> GetMedicos()
        {
            return await _context.Medicos.Include(x => x.ListaEspecialidades)
                            .Select(m => new MedicosViewModel
                            {
                                Id = m.Id,
                                Label = m.Nome + "(Cédula: " + m.NumCedulaProf + ")",
                                Nome = m.Nome,
                                NumCedulaProf = m.NumCedulaProf,
                                NumTelefone = m.NumTelefone,
                                Email = m.Email,
                                DataNascimento = m.DataNascimento.ToString("dd/MM/yyyy"),
                                Foto = m.Foto,
                                Especialidades = m.ListaEspecialidades
                            }).ToListAsync();
        }

        // GET: api/MedicosAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicosViewModel>> GetMedicos(int id)
        {
            var medicos = await _context.Medicos.Select(m => new MedicosViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                NumCedulaProf = m.NumCedulaProf,
                NumTelefone = m.NumTelefone,
                Email = m.Email,
                DataNascimento = m.DataNascimento.ToString("dd/MM/yyyys"),
                Foto = m.Foto,
            }).Where(a => a.Id == id).FirstOrDefaultAsync();

            if (medicos == null)
            {
                return NotFound();
            }

            return medicos;
        }

        // PUT: api/MedicosAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicos(int id, Medicos medicos)
        {
            if (id != medicos.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicosExists(id))
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

        // POST: api/MedicosAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicos>> PostMedicos([FromForm] Medicos medicos, [FromForm] string[] especialidadeId, IFormFile novaFotoMed)
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
                    return BadRequest();
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
            int[] especialidadesId = Array.ConvertAll(especialidadeId, i => int.Parse(i));
            _context.Add(medicos);
            foreach (int especId in especialidadesId)
            {
                var especialidade = await _context.Especialidades.Include(e => e.ListaMedicos).SingleAsync(e => e.Id == especId);
                especialidade.ListaMedicos.Add(medicos);
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
            //medico contém uma lista de especialidades que estava a criar ciclo infinito, logo criar novo medico sem a lista
            return CreatedAtAction("GetMedicos", new { id = medicos.Id }, new Medicos
            {
                Id = medicos.Id,
                Nome = medicos.Nome,
                NumCedulaProf = medicos.NumCedulaProf,
                NumTelefone = medicos.NumTelefone,
                Email = medicos.Email,
                DataNascimento = medicos.DataNascimento,
                Foto = medicos.Foto,
            });


        }

        // DELETE: api/MedicosAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicos(int id)
        {
            var medicos = await _context.Medicos.FindAsync(id);
            if (medicos == null)
            {
                return NotFound();
            }
            // pergunta ao servidor o endereço usar
            string addresoApp = _webHostEnvironment.WebRootPath;
            string localFicheiro = Path.Combine(addresoApp, "Fotos//Medicos");

            //Apaga Foto-----------------------------------------------
            if (Directory.Exists(localFicheiro) && !medicos.Foto.Equals("semFoto.png"))
            {
                FileInfo imgAntiga = new FileInfo(Path.Combine(localFicheiro, medicos.Foto));
                if (imgAntiga.Exists)//verifica se o ficheiro existe
                {
                    imgAntiga.Delete();//se existir elimina
                }
            }

            _context.Medicos.Remove(medicos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicosExists(int id)
        {
            return _context.Medicos.Any(e => e.Id == id);
        }
    }
}
