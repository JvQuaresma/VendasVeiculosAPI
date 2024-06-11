using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculos.Domain.DTOs.Store {
    public class StoreResponseDto {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Veiculos.Domain.Models.Vehicle> Vehicles { get; set; }

    }
}
