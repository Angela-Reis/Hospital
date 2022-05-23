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
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        /// <summary>
        /// Motivo que o Utente Marcou a Consulta
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatório")]
        [StringLength(800, ErrorMessage = "O {0} não pode ter mais do que {1} caracteres.")]
        public string Motivo { get; set; }

        /// <summary>
        /// Estado da Consulta
        /// P=pendente, M=marcada, C=cancelada, F=finalizada
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// FK para o utente
        /// </summary>
        [ForeignKey(nameof(Utente))]
        public int UtenteFK { get; set; }
        public Utentes Utente { get; set; }

        /// <summary>
        /// FK para o Medico
        /// </summary>
        [ForeignKey(nameof(Medico))]
        public int MedicoFK { get; set; }
        public Medicos Medico { get; set; }

        /// <summary>
        /// FK para o Diagnostico
        /// </summary>
        [ForeignKey(nameof(Diagnostico))]
        public int DiagnosticoFK { get; set; }
        public Diagnosticos Diagnostico { get; set; }


    }
}
