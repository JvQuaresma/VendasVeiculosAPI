using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veiculos.Domain.Interfaces.Repositories;
using Veiculos.Domain.Models;
using Veiculos.Infra.Data;

namespace Veiculos.Infra.Repositories {
    public class StoreRepository : IStoreRepository {

        private readonly VehiclesContext _context;
        public StoreRepository(VehiclesContext context) {
            _context = context;
        }

        public async Task<Store> DeleteAsync(int id) {
            try {
                var store = await _context.Stores.Include(l => l.Vehicles).FirstOrDefaultAsync(l => l.Id == id);
                _context.Stores.Remove(store);
                await _context.SaveChangesAsync();
                return store;

            } catch (Exception ex) {
                throw new Exception("Erro ao deletar" + ex.Message);
            }
        }

        public async Task<IEnumerable<Store>> GetAllAsync() {
            var store = await _context.Stores.Include(v => v.Vehicles).ToListAsync();
            return store;
        }

        public async Task<Store> GetByIdAsync(int id) {
            try {
                var store = await _context.Stores.Include(l => l.Vehicles).FirstOrDefaultAsync(l => l.Id == id);
                return store;

            } catch (Exception ex) {
                throw new Exception("Erro ao buscar Id " + ex.Message);
            }
        }

        public async Task<Store> ToAddAsync(Store store) {
            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<Store> UpdateAsync(Store store) {
            try {
                var existingStore = await _context.Stores.FindAsync(store.Id);

                if (existingStore == null)
                    throw new Exception("Loja não encontrada.");

                await _context.SaveChangesAsync();

                return existingStore;

            } catch (Exception ex) {

                throw new Exception("Erro ao tentar atualizar" + ex.Message);
            }
        }
    }
}
