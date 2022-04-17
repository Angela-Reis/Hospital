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
        public string Nome { get; set; }

        public ICollection<Medicos> ListaMedicos { get; set; }


    }
}
