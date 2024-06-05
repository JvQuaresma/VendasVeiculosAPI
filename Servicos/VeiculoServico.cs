using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs.Veiculo;
using VeiculosAPI.Models;
using VeiculosAPI.Repositories;
using VeiculosAPI.Repositories.Interfaces;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Servicos
{
    public class VeiculoServico : IVeiculoServico {

        private readonly IVeiculoRepository _repositorio;
        private readonly ILojaServico _lojaServico;
        private readonly IMapper _mapper;
       
        public VeiculoServico(IVeiculoRepository repository, ILojaServico lojaServico, IMapper mapper) {
           
            _repositorio = repository;
            _lojaServico = lojaServico;
            _mapper = mapper;
        }

        public async Task<VeiculoResponseDto> AdicionarVeiculo(VeiculoRegisterDto veiculoRegisterDto) {

            var loja = await _lojaServico.ObterLoja(veiculoRegisterDto.LojaId);      
            if (loja == null) {
                throw new Exception("Loja não encontrada");
            }

            var veiculo = _mapper.Map<Veiculo>(veiculoRegisterDto);

            await _repositorio.AdicionarAsync(veiculo);

            var response = _mapper.Map<VeiculoResponseDto>(veiculo);
            return response;
            
        }

        public async Task<VeiculoResponseDto> AtualizarVeiculo(VeiculoUpdateDto veiculoDto) {

            var veiculo = _mapper.Map<Veiculo>(veiculoDto);
            var veiculoDb = await _repositorio.AtualizarAsync(veiculo);     
            
            return _mapper.Map<VeiculoResponseDto>(veiculoDb);

        }

        public async Task<VeiculoResponseDto> DeletarVeiculo(int id) {
            
            var veiculo = await _repositorio.DeletarAsync(id);

            return _mapper.Map<VeiculoResponseDto>(veiculo); 
        }

        public async Task<IEnumerable<VeiculoResponseDto>> ObterTodosVeiculos(int page) {

            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;

            var resultado = await _repositorio.ObterTodosAsync(page, limit, offset);
            return _mapper.Map<IEnumerable<VeiculoResponseDto>>(resultado);

        }

        public async Task<VeiculoResponseDto> ObterVeiculo(int id) {
            var veiculo = await _repositorio.ObterPorIdAsync(id);
            if (veiculo == null) {
                throw new Exception("Veículo não encontrado");
            }

            return _mapper.Map<VeiculoResponseDto>(veiculo);
        }
    }
}
