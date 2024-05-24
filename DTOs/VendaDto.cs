namespace VeiculosAPI.DTOs {
    public record VendaDto {

        public int VeiculoId { get; set; }
        public decimal PrecoVendido { get; set; }
        public DateTime DataVenda { get; set; }

    }
}
