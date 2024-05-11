using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces {
    public interface IVeiculoServico {

        Veiculo AdicionarVeiculo(VeiculoDto veiculoDto);
        Veiculo ObterVeiculo(int id);
        IEnumerable<Veiculo> ObterTodosVeiculos(int page);
        void AtualizarVeiculo(int id, VeiculoDto veiculoDto);
        void DeletarVeiculo(int id);

    }
}
