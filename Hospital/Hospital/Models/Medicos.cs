﻿using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    /// <summary>
    /// Medicos do Hospital
    /// </summary>
    public class Medicos
    {
        public Medicos()
        {
            ListaConsultas = new HashSet<Consultas>();
            ListaEspecialidades = new HashSet<Especialidades>();

        }

        /// <summary>
        /// PK da tabela dos Medicos
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Telefone do Medico
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Número de Telemóvel")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem de ter {1} carateres.")]
        [RegularExpression("9[1236][0-9]{7}|2([1-9]{1}[0-9]{7}|[1-9]{2}[0-9]{6})", ErrorMessage = "O {0} não é valido")]
        public string NumTelefone { get; set; }

        /// <summary>
        /// Email do Medico
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [EmailAddress(ErrorMessage = "Deve escrever um {0} válido.")]
        public string Email { get; set; }

        /// <summary>
        /// Nome do Medico
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(128, ErrorMessage = "O {0} não pode ter mais do que {1} caracteres.")]
        [RegularExpression("[A-ZÂÓÍa-záéíóúàèìòùâêîôûãõäëïöüñç '-]+", ErrorMessage = "No {0} só são aceites letras")]
        public string Nome { get; set; }


        /// <summary>
        /// Numero Medico da Cedula Profisional do Medico
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [Display(Name = "Número da Cédula Profissional")]
        public string NumCedulaProf { get; set; }

        /// <summary>
        /// Data de Nascimento do Medico
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Foto do Utente
        /// </summary>
        public string Foto { get; set; }

        /// <summary>
        /// Lista das Consultas do Medico
        /// </summary>
        public ICollection<Consultas> ListaConsultas { get; set; }

        /// <summary>
        /// Lista das Especialidadess do Medico
        /// </summary>
        public ICollection<Especialidades> ListaEspecialidades { get; set; }

    }
}
