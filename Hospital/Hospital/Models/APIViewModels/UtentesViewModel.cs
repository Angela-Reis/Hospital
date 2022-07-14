namespace Hospital.Models.APIViewModels
{
    /// <summary>
    /// Classe define os dados dos Utentes do API
    /// </summary>
    public class UtentesViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Nome { get; set; }
        public string NumUtente { get; set; }
        public string NIF { get; set; }
        public string NumTelefone { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Foto { get; set; }
        //public ICollection<Pagamentos> ListaPagamentos { get; set; }
        //public ICollection<Consultas> ListaConsultas { get; set; }
        //public string IdUtilizador { get; set; }
    }
}
