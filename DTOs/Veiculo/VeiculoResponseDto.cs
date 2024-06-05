using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VeiculosAPI.DTOs.Loja;

namespace VeiculosAPI.DTOs.Veiculo {
    public class VeiculoResponseDto {

       
        public int Id { get; set; }   
        public string Modelo { get; set; }       
        public string Marca { get; set; }
        public int Ano { get; set; }
        public decimal Preco { get; set; }
        public int LojaId { get; set; }    
        public bool Vendido { get; set; }

    }
}
