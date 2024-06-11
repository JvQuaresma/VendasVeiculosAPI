using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.Models;

namespace Veiculos.Domain.Interfaces.Repositories {
    public interface IVehicleRepository {

        public Task<Vehicle> ToAddAsync(Vehicle vehicle);
        public Task<IEnumerable<Vehicle>> GetAllAsync(int page, int limit, int offset);
        public Task<Vehicle> GetByIdAsync(int id);
        public Task<Vehicle> UpdateAsync(Vehicle vehicle);
        public Task<Vehicle> DeleteAsync(int id);

    }
}
