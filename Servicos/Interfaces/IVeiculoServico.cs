using VeiculosAPI.DTOs.Veiculo;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces
{
    public interface IVeiculoServico {

        public Task<VeiculoResponseDto> AdicionarVeiculo(VeiculoRegisterDto veiculoRegisterDto);
        public Task<VeiculoResponseDto> ObterVeiculo(int id);
        public Task<IEnumerable<VeiculoResponseDto>> ObterTodosVeiculos(int page);
        public Task<VeiculoResponseDto> AtualizarVeiculo(VeiculoUpdateDto veiculoDto);
        public Task<VeiculoResponseDto> DeletarVeiculo(int id);

    }
}
