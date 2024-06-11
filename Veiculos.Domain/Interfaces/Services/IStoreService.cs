using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.DTOs.Store;

namespace Veiculos.Domain.Interfaces.Services {
    public interface IStoreService {

        public Task<StoreResponseDto> AddStore(StoreRegisterDto storeRegisterDto);
        public Task<StoreResponseDto> GetStore(int id);
        public Task<IEnumerable<StoreResponseDto>> GetAllStores();
        public Task<StoreResponseDto> UpdateStore(StoreUpdateDto storeDto);
        public Task<StoreResponseDto> DeleteStore(int id);

    }
}
