using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Consultas
    {
        /// <summary>
        /// PK da tabela Consultas
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data que a consulta está marcada
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "A data introduzida não é valida")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}")]
        public DateTime Data { get; set; }

        /// <summary>
        /// Motivo que o Utente Marcou a Consulta
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(800, ErrorMessage = "O {0} não pode ter mais do que {1} caracteres.")]
        public string Motivo { get; set; }

        /// <summary>
        /// Estado da Consulta
        /// P=pendente, M=marcada, C=cancelada, F=finalizada
        /// </summary>
        [RegularExpression("[PpMmCcFf]", ErrorMessage = "Só pode usar P,M,C ou F, no campo {0}, para selecionar pendente, marcada, cancelada ou finalizada respetivamente")]
        public string Estado { get; set; }

        /// <summary>
        /// FK para o utente
        /// </summary>
        [Display(Name = "Utente")]
        [ForeignKey(nameof(Utente))]
        public int UtenteFK { get; set; }
        public Utentes Utente { get; set; }

        /// <summary>
        /// FK para o Medico
        /// </summary>
        [Display(Name = "Medico")]
        [ForeignKey(nameof(Medico))]
        public int MedicoFK { get; set; }
        public Medicos Medico { get; set; }

        /// <summary>
        /// FK para o Diagnostico
        /// </summary>
        [Display(Name = "Diagnostico")]
        [ForeignKey(nameof(Diagnostico))]
        public int? DiagnosticoFK { get; set; }
        public Diagnosticos Diagnostico { get; set; }


    }
}
