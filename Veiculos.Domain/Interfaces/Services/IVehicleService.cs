using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.DTOs.Vehicle;

namespace Veiculos.Domain.Interfaces.Services {
    public interface IVehicleService {

        public Task<VehicleResponseDto> AddVehicle(VehicleRegisterDto vehicleRegisterDto);
        public Task<VehicleResponseDto> GetVehicle(int id);
        public Task<IEnumerable<VehicleResponseDto>> GetAllVehicles(int page);
        public Task<VehicleResponseDto> UpdateVehicle(VehicleUpdateDto vehicleDto);
        public Task<VehicleResponseDto> DeleteVehicle(int id);

    }
}
