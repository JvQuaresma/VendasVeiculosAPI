namespace VeiculosAPI.DTOs.Loja
{
    public record LojaUpdateDto
    {


        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Localizacao { get; set; }


    }
}
