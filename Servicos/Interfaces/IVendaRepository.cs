using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces {
    public interface IVendaRepository {

        public Task<Venda> VenderAsync(VendaDto vendaDto);
        public Task<Venda> ObterPorIdAsync(int id);
        public Task<IEnumerable<Venda>> ObterTodasAsync(int page, int limit, int offset);

    }
}
