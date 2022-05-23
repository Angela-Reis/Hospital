﻿using System.ComponentModel.DataAnnotations;
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
        /// Atributo auxiliar para introduzir o valor do pagamento
        /// </summary>
        [NotMapped]  
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("[0-9]{1,8}[,.]?[0-9]{0,2}", ErrorMessage = "You must write the price of appointement")]
        [Display(Name = "Valor")]
        public string AuxValor { get; set; }
        /// <summary>
        /// Valor do Pagamento
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Descrição do Pagamento
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatório")]

        public string Descricao { get; set; }

        /// <summary>
        /// Estado do pagamento, se foi efetuado ou está pendente
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Data em que foi efetuado o pagamento
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data em que foi efetuado o pagamento")]
        public DateTime DataEfetuado { get; set; }

        /// <summary>
        /// Metodo de pagamento
        /// </summary>
        public string Metodo { get; set; }

        /// <summary>
        /// FK da Consulta a qual o pagamento pertence
        /// </summary>
        [ForeignKey(nameof(Consulta))]
        public int ConsultaFK { get; set; }
        public Consultas Consulta { get; set; }

    }
}
