using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces {
    public interface ILojaServico {

        Loja AdicionarLoja(LojaDto lojaDto);
        Loja ObterLoja(int id);
        IEnumerable<Loja> ObterTodasLojas();
        void AtualizarLoja(int id, LojaDto lojaDto);
        void DeletarLoja(int id);

    }
}
