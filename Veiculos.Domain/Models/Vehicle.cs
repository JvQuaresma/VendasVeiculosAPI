using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veiculos.Domain.Models {
    public class Vehicle {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório")]
        public string Model { get; set; }

        [Required(ErrorMessage = "A marca é obrigatória")]
        public string Brand { get; set; }

        [Range(1900, 2100, ErrorMessage = "O ano deve estar entre 1900 e 2100")]
        public int Year { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }
        public int StoreId { get; set; }

        [JsonIgnore]
        public Store Store { get; set; }
        public bool Sold { get; set; }

    }
}
