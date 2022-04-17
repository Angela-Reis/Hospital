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
        public string Data { get; set; }

        /// <summary>
        /// Motivo que o Utente Marcou a Consulta
        /// </summary>
        public string Motivo { get; set; }

        /// <summary>
        /// Estado da Consulta
        /// P=pendente, M=marcada, C=cancelada, F=finalizada
        /// </summary>
        public string Estado { get; set; }


        [ForeignKey(nameof(Utente))]
        public int UtenteFK { get; set; }
        public Utentes Utente { get; set; }

        [ForeignKey(nameof(Medico))]
        public int MedicoFK { get; set; }
        public Medicos Medico { get; set; }

        [ForeignKey(nameof(Diagnostico))]
        public int DiagnosticoFK { get; set; }
        public Diagnosticos Diagnostico { get; set; }


    }
}
