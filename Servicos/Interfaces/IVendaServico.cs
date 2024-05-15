using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces {
    public interface IVendaServico {

        public Task<Venda> VenderVeiculo(VendaDto vendaDto);
        public Task<Venda> ObterVenda(int id);
        public Task<IEnumerable<Venda>> ObterTodasVendas(int page);

    }
}
