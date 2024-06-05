namespace VeiculosAPI.DTOs.Venda
{
    public record VendaUpdateDto
    {

        public int VeiculoId { get; set; }
        public decimal? PrecoVendido { get; set; }
        public DateTime? DataVenda { get; set; }

    }
}
