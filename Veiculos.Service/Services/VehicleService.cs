using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.DTOs.Vehicle;
using Veiculos.Domain.Interfaces.Repositories;
using Veiculos.Domain.Interfaces.Services;
using Veiculos.Domain.Models;

namespace Veiculos.Service.Services {
    public class VehicleService : IVehicleService {

        private readonly IVehicleRepository _repository;
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository repository, IMapper mapper, IStoreService store) {
            _repository = repository;
            _storeService = store;
            _mapper = mapper;
        }

        public async Task<VehicleResponseDto> AddVehicle(VehicleRegisterDto vehicleRegisterDto) {
            var store = await _storeService.GetStore(vehicleRegisterDto.StoreId);
            if (store == null) {
                throw new Exception("Loja não encontrada");
            }

            var vehicle = _mapper.Map<Vehicle>(vehicleRegisterDto);

            await _repository.ToAddAsync(vehicle);

            var response = _mapper.Map<VehicleResponseDto>(vehicle);
            return response;
        }

        public async Task<VehicleResponseDto> DeleteVehicle(int id) {

            var vehicle = await _repository.DeleteAsync(id);
            return _mapper.Map<VehicleResponseDto>(vehicle);

        }

        public async Task<IEnumerable<VehicleResponseDto>> GetAllVehicles(int page) {

            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;

            var result = await _repository.GetAllAsync(page, limit, offset);
            return _mapper.Map<IEnumerable<VehicleResponseDto>>(result);

        }

        public async Task<VehicleResponseDto> GetVehicle(int id) {

            var vehicle = await _repository.GetByIdAsync(id);
            if (vehicle == null) {
                throw new Exception("Veículo não encontrado");
            }

            return _mapper.Map<VehicleResponseDto>(vehicle);

        }

        public async Task<VehicleResponseDto> UpdateVehicle(VehicleUpdateDto vehicleDto) {
            var vehicle = _mapper.Map<Vehicle>(vehicleDto);
            var vehicleDb = await _repository.UpdateAsync(vehicle);

            return _mapper.Map<VehicleResponseDto>(vehicleDb);
        }
    }
}
