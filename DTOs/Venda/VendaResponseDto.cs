using VeiculosAPI.DTOs.Veiculo;

namespace VeiculosAPI.DTOs.Venda {
    public class VendaResponseDto {

        
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public VeiculosAPI.Models.Veiculo Veiculo { get; set; }       
        public decimal PrecoVendido { get; set; }      
        public DateTime DataVenda { get; set; }

    }
}
