using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Models {
    public class Loja {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da loja é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A localização da loja é obrigatória")]
        public string Localizacao { get; set; }
        public List<Veiculo> Veiculos { get; set; }

    }
}
