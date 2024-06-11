using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Domain.Models {
    public class Store {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da loja é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A localização da loja é obrigatória")]
        public string Location { get; set; }
        public List<Vehicle> Vehicles { get; set; }

    }
}
