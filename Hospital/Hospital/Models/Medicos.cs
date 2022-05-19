namespace Hospital.Models
{
    /// <summary>
    /// Medicos do Hospital
    /// </summary>
    public class Medicos
    {
        public Medicos()
        {
            ListaConsultas = new HashSet<Consultas>();
            ListaEspecialidades = new HashSet<Especialidades>();

        }

        /// <summary>
        /// PK da tabela dos Medicos
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Email do Medico
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Nome do Medico
        /// </summary>
        public string Nome { get; set; }


        /// <summary>
        /// Numero Medico da Cedula Profisional do Medico
        /// </summary>
        public string NumCedulaProf { get; set; }

        /// <summary>
        /// Data de Nascimento do Medico
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Sexo do Medico
        /// Ff=female, Mm=male
        /// </summary>
        public string Sexo { get; set; }


        /// <summary>
        /// Foto do Utente
        /// </summary>
        public string Foto { get; set; }

        /// <summary>
        /// Lista das Consultas do Medico
        /// </summary>
        public ICollection<Consultas> ListaConsultas { get; set; }

        /// <summary>
        /// Lista de Especialidades Médicas do Medico
        /// </summary>
        public ICollection<Especialidades> ListaEspecialidades { get; set; }

    }
}
