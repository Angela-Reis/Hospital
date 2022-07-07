namespace Hospital.Models.APIViewModels
{
    /// <summary>
    /// Classe define os dados das Especialidades do API
    /// </summary>
    public class EspecialidadesViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
