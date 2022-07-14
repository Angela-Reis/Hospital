namespace Hospital.Models.APIViewModels
{
    /// <summary>
    /// Classe define os dados das Diagnosticos do API
    /// </summary>
    public class DiagnosticosViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string Utente { get; set; }
    }
}
