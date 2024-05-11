namespace VeiculosAPI.DTOs {
    public class VeiculoRegisterDto {

        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public decimal Preco { get; set; }
        public int LojaId { get; set; }

    }
}
