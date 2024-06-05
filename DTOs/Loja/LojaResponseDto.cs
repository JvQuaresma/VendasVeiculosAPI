using VeiculosAPI.DTOs.Veiculo;

namespace VeiculosAPI.DTOs.Loja {
    public class LojaResponseDto {

        
        public int Id { get; set; }      
        public string Nome { get; set; }       
        public string Localizacao { get; set; }
        public List<VeiculosAPI.Models.Veiculo> Veiculos { get; set; }

    }
}
