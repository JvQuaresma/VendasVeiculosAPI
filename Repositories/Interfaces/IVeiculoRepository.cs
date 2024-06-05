using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Repositories.Interfaces
{
    public interface IVeiculoRepository
    {

        public Task<Veiculo> AdicionarAsync(Veiculo veiculo);
        public Task<IEnumerable<Veiculo>> ObterTodosAsync(int page, int limit, int offset);
        public Task<Veiculo> ObterPorIdAsync(int id);
        public Task<Veiculo> AtualizarAsync(Veiculo veiculo);
        public Task<Veiculo> DeletarAsync(int id);

    }
}
