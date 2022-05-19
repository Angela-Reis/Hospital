using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Prescricoes
    {
        /// <summary>
        /// PK da tabela Prescicao
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descricao da Prescicao
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data em que a Prescicao foi efetuada
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Estado da prescicao se está ativa ou desativa
        /// </summary>
        public bool Estado { get; set; }

        [ForeignKey(nameof(Diagnostico))]
        public int DiagnosticoFK { get; set; }
        public Diagnosticos Diagnostico { get; set; }


    }
}
