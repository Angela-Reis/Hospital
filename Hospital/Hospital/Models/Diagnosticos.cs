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
        /// PK tabela Diagnosticos
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descrição do Diagnostico
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
        [RegularExpression("[A-Za-z ]+", ErrorMessage = "No {0} só são aceites letras")]
        public string Descricao { get; set; }


        /// <summary>
        /// Estado do Diagnostico
        /// T=Tratamento, C=Cronico
        /// </summary>
        [RegularExpression("[TtCc]", ErrorMessage = "Só pode usar T, ou C, no campo {0}")]
        public string Estado { get; set; }

        /// <summary>
        /// Lista de Consultas Relaciondas com o Diagnostico
        /// </summary>
        public ICollection<Consultas> ListaConsultas { get; set; }

        /// <summary>
        /// Lista das Prescicao que foram utilizadas para o Dignostico
        /// </summary>
        public ICollection<Prescricoes> ListaPrescricao { get; set; }


    }
}
