using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.DTOs.Sale;

namespace Veiculos.Domain.Interfaces.Services {
    public interface ISaleService {

        public Task<SaleResponseDto> SellVehicle(SaleUpdateDto saleDto);
        public Task<SaleResponseDto> GetSale(int id);
        public Task<IEnumerable<SaleResponseDto>> GetAllSales(int page);

    }
}
