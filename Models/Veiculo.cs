using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VeiculosAPI.Models {
    public class Veiculo {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A marca é obrigatória")]
        public string Marca { get; set; }

        [Range(1900, 2100, ErrorMessage = "O ano deve estar entre 1900 e 2100")]
        public int Ano { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }
        public int LojaId { get; set; }

        [JsonIgnore]
        public Loja Loja { get; set; }
        public bool Vendido { get; set; }

    }
}
