using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces {
    public interface ILojaServico {

        public Task<Loja> AdicionarLoja(LojaRegisterDto lojaRegisterDto);
        public Task<Loja> ObterLoja(int id);
        public Task<IEnumerable<Loja>> ObterTodasLojas();
        public Task<Loja> AtualizarLoja (LojaDto lojaDto);
        public Task<Loja> DeletarLoja(int id);

    }
}
