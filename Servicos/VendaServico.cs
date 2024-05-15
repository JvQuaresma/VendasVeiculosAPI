using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Servicos {
    public class VendaServico : IVendaServico {

        private readonly VendasVeiculoContext _context;

        public VendaServico(VendasVeiculoContext context) {

            _context = context;

        }

        public async Task<IEnumerable<Venda>> ObterTodasVendas(int page) {

            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;

            return await _context.Vendas.Skip(offset).Take(limit).Include(l => l.Veiculo).ToListAsync();
            
        }

        public async Task<Venda> ObterVenda(int id) {
            var venda = await _context.Vendas.Include(l => l.Veiculo).FirstOrDefaultAsync(l => l.Id == id);
            if (venda == null) {
                throw new Exception("Venda não encontrada");
            }

            return venda;
            
        }

        public async Task<Venda> VenderVeiculo(VendaDto vendaDto) {
            var veiculo = await _context.Veiculos.FindAsync(vendaDto.VeiculoId);
            if (veiculo == null ) {

                throw new Exception("O id do véiculo não pode ser vazio.");

            }else if (veiculo.Vendido){

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

        }
    }
}
