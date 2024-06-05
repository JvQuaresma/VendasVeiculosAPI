using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs.Loja;
using VeiculosAPI.Models;
using VeiculosAPI.Repositories.Interfaces;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Servicos
{
    public class LojaServico : ILojaServico {

        private readonly ILojaRepository _repositorio;
        private readonly IMapper _mapper;

        public LojaServico(ILojaRepository repositorio, IMapper mapper) {
           
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<LojaResponseDto> AdicionarLoja(LojaRegisterDto lojaRegisterDto) {
       
            var loja = _mapper.Map<Loja>(lojaRegisterDto);

            await _repositorio.AdicionarAsync(loja);

            return _mapper.Map<LojaResponseDto>(loja);
            
        }

        public async Task<LojaResponseDto> ObterLoja(int id) {

            var loja = await _repositorio.ObterPorIdAsync(id);          
            return _mapper.Map<LojaResponseDto>(loja);
        }

        public async Task<IEnumerable<LojaResponseDto>> ObterTodasLojas() {

            var loja = await _repositorio.ObterTodasAsync();
            return _mapper.Map<IEnumerable<LojaResponseDto>>(loja);
        }

        public async Task<LojaResponseDto> AtualizarLoja(LojaUpdateDto lojaDto) {

            var loja = _mapper.Map<Loja>(lojaDto);
            var lojaExistente = await _repositorio.AtualizarAsync(loja);
           
            return _mapper.Map<LojaResponseDto>(lojaExistente);
        }

        public async Task<LojaResponseDto> DeletarLoja(int id) {
            
            var loja = await _repositorio.DeletarAsync(id);
            return _mapper.Map<LojaResponseDto>(loja);
        }

    }
}
