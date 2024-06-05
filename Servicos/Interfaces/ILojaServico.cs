using VeiculosAPI.DTOs.Loja;
using VeiculosAPI.Models;

namespace VeiculosAPI.Servicos.Interfaces
{
    public interface ILojaServico {

        public Task<LojaResponseDto> AdicionarLoja(LojaRegisterDto lojaRegisterDto);
        public Task<LojaResponseDto> ObterLoja(int id);
        public Task<IEnumerable<LojaResponseDto>> ObterTodasLojas();
        public Task<LojaResponseDto> AtualizarLoja (LojaUpdateDto lojaDto);
        public Task<LojaResponseDto> DeletarLoja(int id);

    }
}
