using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;
using VeiculosAPI.Repositories;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Servicos {
    public class VeiculoServico : IVeiculoServico {

        private readonly IVeiculoRepository _repositorio;
        private readonly ILojaServico _lojaServico;
        private readonly IMapper _mapper;

        private readonly VendasVeiculoContext _context;

        public VeiculoServico(VendasVeiculoContext context, IVeiculoRepository repository, ILojaServico lojaServico, IMapper mapper) {

            _context = context;
            _repositorio = repository;
            _lojaServico = lojaServico;
            _mapper = mapper;
        }

        public async Task<Veiculo> AdicionarVeiculo(VeiculoRegisterDto veiculoRegisterDto) {

            var loja = await _lojaServico.ObterLoja(veiculoRegisterDto.LojaId);      
            if (loja == null) {
                throw new Exception("Loja não encontrada");
            }

            var veiculo = _mapper.Map<Veiculo>(veiculoRegisterDto);

            await _repositorio.AdicionarAsync(veiculo);

            return veiculo;
            
        }

        public async Task<Veiculo> AtualizarVeiculo(VeiculoDto veiculoDto) {

            var veiculoDb = await _repositorio.AtualizarAsync(veiculoDto);           
            return veiculoDb;
           
        }

        public async Task<Veiculo> DeletarVeiculo(int id) {
            
            var veiculo = await _repositorio.DeletarAsync(id);

            return veiculo;
        }

        public async Task<IEnumerable<Veiculo>> ObterTodosVeiculos(int page) {

            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;

            var resultado = await _repositorio.ObterTodosAsync(page, limit, offset);
            return resultado;

        }

        public async Task<Veiculo> ObterVeiculo(int id) {
            var veiculo = await _repositorio.ObterPorIdAsync(id);
            if (veiculo == null) {
                throw new Exception("Veículo não encontrado");
            }

            return veiculo; 
        }
    }
}
