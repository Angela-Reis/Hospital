using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    /// <summary>
    /// Lista de Especilidades que o Hospital disponibiliza
    /// </summary>
    public class Especialidades
    {
        public Especialidades()
        {
            ListaMedicos = new HashSet<Medicos>();
        }

        /// <summary>
        /// PK da tabela Especialidade
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da Especialidade
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("[A-Za-z ]+", ErrorMessage = "No {0} só são aceites letras")]
        public string Nome { get; set; }

        /// <summary>
        /// Lista de médicos da especialidade
        /// </summary>
        public ICollection<Medicos> ListaMedicos { get; set; }


    }
}
