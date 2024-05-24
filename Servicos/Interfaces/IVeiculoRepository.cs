using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces {
    public interface IVeiculoRepository {

        public Task<Veiculo> AdicionarAsync(Veiculo veiculo);
        public Task<IEnumerable<Veiculo>> ObterTodosAsync(int page, int limit, int offset);
        public Task<Veiculo> ObterPorIdAsync(int id);
        public Task<Veiculo> AtualizarAsync(VeiculoDto veiculoDto);
        public Task<Veiculo> DeletarAsync(int id);

    }
}
