using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces {
    public interface IVeiculoServico {

        Veiculo AdicionarVeiculo(VeiculoRegisterDto veiculoRegisterDto);
        Veiculo ObterVeiculo(int id);
        IEnumerable<Veiculo> ObterTodosVeiculos(int page);
        void AtualizarVeiculo(VeiculoDto veiculoDto);
        void DeletarVeiculo(int id);

    }
}
