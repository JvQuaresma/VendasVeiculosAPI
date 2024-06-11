using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Domain.DTOs.Vehicle {
    public class VehicleUpdateDto {

        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public int? Year { get; set; }
        public decimal? Price { get; set; }
        public bool? Sold { get; set; }

    }
}
