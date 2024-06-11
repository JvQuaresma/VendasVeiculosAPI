using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.DTOs.Sale;
using Veiculos.Domain.Interfaces.Repositories;
using Veiculos.Domain.Interfaces.Services;
using Veiculos.Domain.Models;

namespace Veiculos.Service.Services {
    public class SaleService : ISaleService {

        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SaleResponseDto>> GetAllSales(int page) {
            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;

            var result = await _repository.GetAllAsync(page, limit, offset);

            return _mapper.Map<IEnumerable<SaleResponseDto>>(result);
        }

        public async Task<SaleResponseDto> GetSale(int id) {
            var sale = await _repository.GetByIdAsync(id);
            return _mapper.Map<SaleResponseDto>(sale);
        }

        public async Task<SaleResponseDto> SellVehicle(SaleUpdateDto saleDto) {
            var sale = _mapper.Map<Sale>(saleDto);
            var saleRS = await _repository.SellAsync(sale);

            return _mapper.Map<SaleResponseDto>(saleRS);
        }
    }
}
