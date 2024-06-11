using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Domain.DTOs.Vehicle {
    public class VehicleRegisterDto {

        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int StoreId { get; set; }

    }
}
