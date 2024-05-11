using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces {
    public interface IVendaServico {

        Venda VenderVeiculo(VendaDto vendaDto);
        Venda ObterVenda(int id);
        IEnumerable<Venda> ObterTodasVendas(int page);

    }
}
