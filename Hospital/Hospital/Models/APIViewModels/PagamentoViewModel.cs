namespace Hospital.Models.APIViewModels
{
    /// <summary>
    /// Classe define os dados das Pagamento do API
    /// </summary>
    public class PagamentoViewModel
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string? DataEfetuado { get; set; }
        public string Metodo { get; set; }
        public string Consulta { get; set; }

    }

}
