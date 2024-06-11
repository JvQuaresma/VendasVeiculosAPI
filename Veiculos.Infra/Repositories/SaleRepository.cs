using Microsoft.EntityFrameworkCore;
using Veiculos.Domain.Interfaces.Repositories;
using Veiculos.Domain.Models;
using Veiculos.Infra.Data;
using Veiculos.Service.Global;

namespace Veiculos.Infra.Repositories {
    public class SaleRepository : ISaleRepository {

        private readonly VehiclesContext _context;
        public SaleRepository(VehiclesContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Sale>> GetAllAsync(int page, int limit, int offset) {
            var result = await _context.Sales.Skip(offset).Take(limit).Include(l => l.Vehicle).ToListAsync();
            return result;
        }

        public async Task<Sale> GetByIdAsync(int id) {
            try {
                var result = await _context.Sales.Include(l => l.Vehicle).FirstOrDefaultAsync(l => l.Id == id);
                return result;

            } catch (Exception ex) {

                throw new Exception("Venda não encontrada" + ex.Message);
            }
        }

        public async Task<Sale> SellAsync(Sale sale) {
            try {
                var vehicle = await _context.Vehicles.FindAsync(sale.VehicleId);
                if (vehicle == null) {

                    throw new Exception("O id do véiculo não pode ser vazio.");

                } else if (vehicle.Sold) {

                    throw new Exception("Este veículo ja está vendido.");
                }

                await _context.Sales.AddAsync(sale);
                await _context.SaveChangesAsync();

                vehicle.Sold = true;
                await _context.SaveChangesAsync();

                Functions.LogToFile("Vender Veículo - Sucesso", "Venda Efetuada com Sucesso.");

                return sale;

            } catch (Exception ex) {

                Functions.LogToFile("Vender Veículo - Erro", ex.Message);
                throw new Exception("Erro ao tentar efetuar a venda." + ex.Message);

            }
        }
    }
}
