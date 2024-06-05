using VeiculosAPI.DTOs;
using VeiculosAPI.Models;

namespace VeiculosAPI.Repositories.Interfaces
{
    public interface ILojaRepository
    {

        public Task<Loja> AdicionarAsync(Loja loja);
        public Task<Loja> ObterPorIdAsync(int id);
        public Task<IEnumerable<Loja>> ObterTodasAsync();
        public Task<Loja> AtualizarAsync(Loja loja);
        public Task<Loja> DeletarAsync(int id);

    }
}
