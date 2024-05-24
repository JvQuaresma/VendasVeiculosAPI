namespace VeiculosAPI.DTOs {
    public record VeiculoDto {

        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public decimal Preco { get; set; }
        public int LojaId { get; set; }
        public bool Vendido { get; set; }

    }
}
