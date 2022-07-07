namespace Hospital.Models.APIViewModels
{
    /// <summary>
    /// Classe define os dados das Prescricoes do API
    /// </summary>
    public class PrescricoesViewModel
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }
        public string Diagnostico { get; set; }


    }
}
