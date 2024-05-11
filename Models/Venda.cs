using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Models {
    public class Venda {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O preço vendido deve ser maior que zero")]
        public decimal PrecoVendido { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataVenda {  get; set; }
           
        

    }
}
