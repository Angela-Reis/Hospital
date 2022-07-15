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
        /// Título do Diagnóstico
        /// </summary>
        [Display(Name = "Título")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("[A-Za-z ]+", ErrorMessage = "No {0} só são aceites letras")]
        [StringLength(60, ErrorMessage = "O {0} não pode ter mais do que {1} caracteres")]
        public string Titulo { get; set; }

        /// <summary>
        /// Descrição Opcional do Diagnóstico
        /// </summary>
        [Display(Name = "Descrição")]
        [RegularExpression("[A-Za-z ]+", ErrorMessage = "Na {0} só são aceites letras")]
        [StringLength(1000, ErrorMessage = "O {0} não pode ter mais do que {1} caracteres")]
        public string Descricao { get; set; }


        /// <summary>
        /// Estado do Diagnóstico
        /// T=Tratamento, F=Tratado, C=Cronico
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("[TtFfCc]", ErrorMessage = "Só pode usar T, F, ou C, no campo {0}, sendo que correspondem a em tratamento, finalazido(Curado) ou Crónico respetivamente")]
        [StringLength(1, ErrorMessage = "O {0} não pode ter mais do que {1} caracteres")]
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
