using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Diagnosticos
    {
        public Diagnosticos()
        {
            ListaConsultas = new HashSet<Consultas>();
            ListaPrescricao = new HashSet<Prescricoes>();
        }
        /// <summary>
        /// PK da tabela de Diagnóstico
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descrição do Diagnóstico
        /// </summary>
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
        [RegularExpression("[A-Za-z ]+", ErrorMessage = "No {0} só são aceites letras")]
        [StringLength(1000, ErrorMessage = "O {0} não pode ter mais do que {1} caracteres.")]
        public string Descricao { get; set; }


        /// <summary>
        /// Estado do Diagnóstico
        /// T=Tratamento, F=Tratado, C=Cronico
        /// </summary>
        [RegularExpression("[TtFfCc]", ErrorMessage = "Só pode usar T, F, ou C, no campo {0}, sendo que correspondem a em tratamento, finalazido ou cronico respetivamente")]
        public string Estado { get; set; }

        /// <summary>
        /// Lista de Consultas Relaciondas com o Diagnóstico
        /// </summary>
        public ICollection<Consultas> ListaConsultas { get; set; }

        /// <summary>
        /// Lista das Prescricoes que foram atribuidas ao Diagnóstico
        /// </summary>
        public ICollection<Prescricoes> ListaPrescricao { get; set; }


    }
}
