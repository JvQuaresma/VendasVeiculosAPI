using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.DTOs.Store;
using Veiculos.Domain.Interfaces.Repositories;
using Veiculos.Domain.Interfaces.Services;
using Veiculos.Domain.Models;

namespace Veiculos.Service.Services {
    public class StoreService : IStoreService {

        private readonly IStoreRepository _repository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StoreResponseDto> AddStore(StoreRegisterDto storeRegisterDto) {
            var store = _mapper.Map<Store>(storeRegisterDto);

            await _repository.ToAddAsync(store);

            return _mapper.Map<StoreResponseDto>(store);
        }

        public async Task<StoreResponseDto> DeleteStore(int id) {
            var store = await _repository.DeleteAsync(id);
            return _mapper.Map<StoreResponseDto>(store);
        }

        public async Task<IEnumerable<StoreResponseDto>> GetAllStores() {
            var store = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StoreResponseDto>>(store);
        }

        public async Task<StoreResponseDto> GetStore(int id) {
            var store = await _repository.GetByIdAsync(id);
            return _mapper.Map<StoreResponseDto>(store);
        }

        public async Task<StoreResponseDto> UpdateStore(StoreUpdateDto storeDto) {
            var store = _mapper.Map<Store>(storeDto);
            var existingStore = await _repository.UpdateAsync(store);

            return _mapper.Map<StoreResponseDto>(existingStore);
        }
    }
}
