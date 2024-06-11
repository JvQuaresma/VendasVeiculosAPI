using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.Models;

namespace Veiculos.Domain.Interfaces.Repositories {
    public interface IStoreRepository {

        public Task<Store> ToAddAsync(Store store);
        public Task<Store> GetByIdAsync(int id);
        public Task<IEnumerable<Store>> GetAllAsync();
        public Task<Store> UpdateAsync(Store store);
        public Task<Store> DeleteAsync(int id);

    }
}
