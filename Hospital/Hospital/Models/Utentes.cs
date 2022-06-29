using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    /// <summary>
    /// Dados de um utente do hospital
    /// </summary>
    public class Utentes
    {
        
        public Utentes()
        {
            ListaPagamentos = new HashSet<Pagamentos>();
            ListaConsultas = new HashSet<Consultas>();
        }

        /// <summary>
        /// PK da tabela dos Utentes
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Telefone do Utente
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatório")]
        [Display(Name = "Número de Telemóvel")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem de ter {1} carateres.")]
        [RegularExpression("9[1236][0-9]{7}|2[1-9]{1}[0-9]{7}|2[1-9]{2}[0-9]{6}", ErrorMessage = "O {0} não é valido")]
        public string NumTelemovel { get; set; }

        /// <summary>
        /// Email do Utente
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatório")]
        [EmailAddress(ErrorMessage = "Deve escrever um {0} válido.")]
        public string Email { get; set; }

        /// <summary>
        /// Nome do Utente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(128, ErrorMessage = "O {0} não pode ter mais do que {1} caracteres.")]
        [RegularExpression("[A-ZÂÓÍa-záéíóúàèìòùâêîôûãõäëïöüñç '-]+", ErrorMessage = "No {0} só são aceites letras")]
        public string Nome { get; set; }

        /// <summary>
        /// Numero de Utente do Utente
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatório")]
        [Display(Name = "Número de Utente")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem de ter 9 carateres.")]
        [RegularExpression("[1235789][0-9]{8}", ErrorMessage = "O {0} deve começar por 1,2,3,5,7,8,9 seguido de 8 digitos numéricos.")]
        public string NumUtente { get; set; }

        /// <summary>
        /// NIF do Utente
        /// </summary>
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem de ter 9 carateres.")]
        [RegularExpression("[123578][0-9]{8}", ErrorMessage = "O {0} deve começar por 1,2,3,5,7,8 seguido de 8 digitos numéricos.")]
        public string NIF { get; set; }

        /// <summary>
        /// Data de Nascimento do Utente
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Sexo do Utente
        /// Ff=female, Mm=male
        /// </summary>
        [RegularExpression("[MmFf]", ErrorMessage = "Só pode usar F, ou M, no campo {0}")]
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatório")]
        public string Sexo { get; set; }


        /// <summary>
        /// Foto do Utente
        /// </summary>
        public string Foto { get; set; }

        /// <summary>
        /// Lista dos Pagamentos do Utente
        /// </summary>
        public ICollection<Pagamentos> ListaPagamentos { get; set; }

        /// <summary>
        /// Lista das Consultas do Utente
        /// </summary>
        public ICollection<Consultas> ListaConsultas { get; set; }

        /// <summary>
        /// FK para conectar com a tabela de Autentificação
        /// </summary>
        public string IdUtilizador { get; set; }


    }
}
