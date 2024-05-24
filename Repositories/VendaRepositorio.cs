using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Repositories {
    public class VendaRepositorio : IVendaRepository {

        private readonly VendasVeiculoContext _context;

        public VendaRepositorio(VendasVeiculoContext context) {
            _context = context;
        }

        public async Task<Venda> ObterPorIdAsync(int id) {
            try {
                var resultado = await _context.Vendas.Include(l => l.Veiculo).FirstOrDefaultAsync(l => l.Id == id);
                return resultado;

            } catch (Exception ex) {

                throw new Exception("Venda não encontrada" + ex.Message);
            }

        }

        public async Task<IEnumerable<Venda>> ObterTodasAsync(int page, int limit, int offset) {

            var resultado = await _context.Vendas.Skip(offset).Take(limit).Include(l => l.Veiculo).ToListAsync();
            return resultado;
        }

        public async Task<Venda> VenderAsync(VendaDto vendaDto) {
            try {
                var veiculo = await _context.Veiculos.FindAsync(vendaDto.VeiculoId);
                if (veiculo == null) {

                    throw new Exception("O id do véiculo não pode ser vazio.");

                } else if (veiculo.Vendido) {

                    throw new Exception("Este veículo ja está vendido.");
                }

                var venda = new Venda {
                    VeiculoId = vendaDto.VeiculoId,
                    Veiculo = veiculo,
                    PrecoVendido = vendaDto.PrecoVendido,
                    DataVenda = vendaDto.DataVenda
                };

                await _context.Vendas.AddAsync(venda);
                await _context.SaveChangesAsync();

                veiculo.Vendido = true;
                await _context.SaveChangesAsync();

                return venda;

            } catch (Exception ex) {
                throw new Exception("Erro ao tentar efetuar a venda." + ex.Message);
            }
        }
    }
}
