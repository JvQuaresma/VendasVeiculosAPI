using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Domain.DTOs.Sale {
    public class SaleResponseDto {

        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Veiculos.Domain.Models.Vehicle Vehicle { get; set; }
        public decimal SoldPrice { get; set; }
        public DateTime SaleDate { get; set; }

    }
}
