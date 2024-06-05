using VeiculosAPI.DTOs.Venda;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces
{
    public interface IVendaServico {

        public Task<VendaResponseDto> VenderVeiculo(VendaUpdateDto vendaDto);
        public Task<VendaResponseDto> ObterVenda(int id);
        public Task<IEnumerable<VendaResponseDto>> ObterTodasVendas(int page);

    }
}
