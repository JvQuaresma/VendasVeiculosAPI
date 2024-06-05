using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Repositories.Interfaces
{
    public interface IVendaRepository
    {

        public Task<Venda> VenderAsync(Venda venda);
        public Task<Venda> ObterPorIdAsync(int id);
        public Task<IEnumerable<Venda>> ObterTodasAsync(int page, int limit, int offset);

    }
}
