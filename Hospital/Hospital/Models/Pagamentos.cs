using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    /// <summary>
    /// Dados do pagamento de uma consulta
    /// </summary>
    public class Pagamentos
    {
        /// <summary>
        /// PK para identificar o pagamento
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Valor do Pagamento
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// Estado do pagamento, se foi efetuado ou está pendente
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Data de quando foi efetuado o pagamento
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Metodo de pagamento
        /// </summary>
        public string Metodo { get; set; }


        [ForeignKey(nameof(Consulta))]
        public int ConsultaFK { get; set; }
        public Consultas Consulta { get; set; }

    }
}
