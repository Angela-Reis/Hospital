using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        /// <summary>
        /// Data em que a Prescicao foi efetuada
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        
        /// <summary>
        /// Estado da prescicao se está ativa ou desativa
        /// </summary>
        public bool Estado { get; set; }


        /// <summary>
        /// FK do Diagnostico para qual a prescrição é necessaria
        /// </summary>
        [ForeignKey(nameof(Diagnostico))]
        public int DiagnosticoFK { get; set; }
        public Diagnosticos Diagnostico { get; set; }


    }
}
