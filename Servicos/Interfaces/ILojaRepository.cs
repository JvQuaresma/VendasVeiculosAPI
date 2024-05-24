using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces {
    public interface ILojaRepository {

        public Task<Loja> AdicionarAsync(Loja loja);
        public Task<Loja> ObterPorIdAsync(int id);
        public Task<IEnumerable<Loja>> ObterTodasAsync();
        public Task<Loja> AtualizarAsync(LojaDto lojaDto);
        public Task<Loja> DeletarAsync(int id);

    }
}
