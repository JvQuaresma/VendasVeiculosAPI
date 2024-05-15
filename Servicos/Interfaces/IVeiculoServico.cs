using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces {
    public interface IVeiculoServico {

        public Task<Veiculo> AdicionarVeiculo(VeiculoRegisterDto veiculoRegisterDto);
        public Task<Veiculo> ObterVeiculo(int id);
        public Task<IEnumerable<Veiculo>> ObterTodosVeiculos(int page);
        public Task<Veiculo> AtualizarVeiculo(VeiculoDto veiculoDto);
        public Task<Veiculo> DeletarVeiculo(int id);

    }
}
