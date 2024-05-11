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

        public IEnumerable<Venda> ObterTodasVendas(int page) {

            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;

            return _context.Vendas.Skip(offset).Take(limit).Include(l => l.Veiculo).ToList();
            
        }

        public Venda ObterVenda(int id) {
            var venda = _context.Vendas.Include(l => l.Veiculo).FirstOrDefault(l => l.Id == id);
            if (venda == null) {
                throw new Exception("Venda não encontrada");
            }

            return venda;
            
        }

        public Venda VenderVeiculo(VendaDto vendaDto) {
            var veiculo = _context.Veiculos.Find(vendaDto.VeiculoId);
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

            _context.Vendas.Add(venda);
            _context.SaveChanges();

            veiculo.Vendido = true;
            _context.SaveChanges();

            return venda;

        }
    }
}
