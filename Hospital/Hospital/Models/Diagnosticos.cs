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
        public string Descricao { get; set; }


        /// <summary>
        /// Estado do Diagnostico
        /// T=Tratamento, C=Cronico
        /// </summary>
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
