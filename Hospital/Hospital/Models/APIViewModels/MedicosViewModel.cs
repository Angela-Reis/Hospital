namespace Hospital.Models.APIViewModels
{

    /// <summary>
    /// Classe define os dados dos Médicos do API
    /// </summary>
    public class MedicosViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Nome { get; set; }
        public string NumCedulaProf { get; set; }
        public string NumTelefone { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Foto { get; set; }
        public ICollection<Especialidades> Especialidades { get; set; }
        //public ICollection<Consultas> ListaConsultas { get; set; }
        //public string IdUtilizador { get; set; }
    }
}
