namespace Hospital.Models
{
    /// <summary>
    /// Dados de um utente do hospital
    /// </summary>
    public class Utentes
    {
        
        public Utentes()
        {
            ListaPagamentos = new HashSet<Pagamentos>();
            ListaConsultas = new HashSet<Consultas>();
        }

        /// <summary>
        /// PK da tabela dos Utentes
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Email do Utente
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Nome do Utente
        /// </summary>
        public string Nome { get; set; }


        /// <summary>
        /// Numero Utente do hospital
        /// </summary>
        public string NumUtente { get; set; }

        /// <summary>
        /// Data de Nascimento do Utente
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Sexo do Utente
        /// Ff=female, Mm=male
        /// </summary>
        public string Sexo { get; set; }


        /// <summary>
        /// Foto do Utente
        /// </summary>
        public string Foto { get; set; }

        /// <summary>
        /// Lista dos Pagamentos do Utente
        /// </summary>
        public ICollection<Pagamentos> ListaPagamentos { get; set; }

        /// <summary>
        /// Lista das Consultas do Utente
        /// </summary>
        public ICollection<Consultas> ListaConsultas { get; set; }


        
    }
}
