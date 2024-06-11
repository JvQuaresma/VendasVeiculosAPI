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
    public class VehicleRepository : IVehicleRepository {

        private readonly VehiclesContext _context;
        public VehicleRepository(VehiclesContext context) {
            _context = context;
        }

        public async Task<Vehicle> DeleteAsync(int id) {
            try {
                var vehicle = await _context.Vehicles.FindAsync(id);
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
                return vehicle;

            } catch (Exception ex) {
                throw new Exception("Erro ao deletar" + ex.Message);
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync(int page, int limit, int offset) {
            var result = await _context.Vehicles.Skip(offset).Take(limit).ToListAsync();
            return result;
        }

        public async Task<Vehicle> GetByIdAsync(int id) {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<Vehicle> ToAddAsync(Vehicle vehicle) {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<Vehicle> UpdateAsync(Vehicle vehicle) {
            try {
                var vehicleDb = await _context.Vehicles.FindAsync(vehicle.Id);
                if (vehicleDb == null) {

                    throw new Exception("Veículo não encontrado");

                }

                var store = await _context.Stores.FindAsync(vehicle.StoreId);
                if (store == null) {

                    throw new Exception("Loja não encontrada");

                }


                await _context.SaveChangesAsync();

                return vehicleDb;

            } catch (Exception ex) {
                throw new Exception("Erro ao atualizar" + ex.Message);
            }
        }
    }
}
