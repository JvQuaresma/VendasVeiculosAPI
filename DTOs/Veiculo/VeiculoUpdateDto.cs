namespace VeiculosAPI.DTOs.Veiculo
{
    public record VeiculoUpdateDto
    {

        public int Id { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
        public int? Ano { get; set; }
        public decimal? Preco { get; set; }
        public bool? Vendido { get; set; }

    }
}
