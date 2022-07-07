namespace Hospital.Models.APIViewModels
{
    /// <summary>
    /// Classe define os dados das Consultas do API
    /// </summary>
    public class ConsultasViewModel
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public string Utente { get; set; }
        public string Medico { get; set; }
        public string Diagnostico { get; set; }

    }
}
