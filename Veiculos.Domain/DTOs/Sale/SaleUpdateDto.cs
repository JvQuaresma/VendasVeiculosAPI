using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Domain.DTOs.Sale {
    public class SaleUpdateDto {

        public int VehicleId { get; set; }
        public decimal? SoldPrice { get; set; }
        public DateTime? SaleDate { get; set; }

    }
}
