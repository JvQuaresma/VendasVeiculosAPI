using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs.Venda;
using VeiculosAPI.Models;
using VeiculosAPI.Repositories.Interfaces;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Servicos
{
    public class VendaServico : IVendaServico {

        private readonly IVendaRepository _repositorio;
        private readonly IMapper _mapper;

        public VendaServico(IVendaRepository repositorio, IMapper mapper) {
           
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VendaResponseDto>> ObterTodasVendas(int page) {

            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;

            var resultado = await _repositorio.ObterTodasAsync(page, limit, offset);

            return _mapper.Map<IEnumerable<VendaResponseDto>>(resultado);
        }

        public async Task<VendaResponseDto> ObterVenda(int id) {

            var venda = await _repositorio.ObterPorIdAsync(id);         
            return _mapper.Map<VendaResponseDto>(venda);

        }

        public async Task<VendaResponseDto> VenderVeiculo(VendaUpdateDto vendaDto) {
           
            var venda = _mapper.Map<Venda>(vendaDto);
            var vendaRS = await _repositorio.VenderAsync(venda);

            return _mapper.Map<VendaResponseDto>(vendaRS);

        }
    }
}
