using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Servicos {
    public class LojaServico : ILojaServico {

        private readonly VendasVeiculoContext _context;
        private readonly ILojaRepository _repositorio;

        public LojaServico(VendasVeiculoContext context, ILojaRepository repositorio) {

            _context = context;
            _repositorio = repositorio;
        }

        public async Task<Loja> AdicionarLoja(LojaRegisterDto lojaRegisterDto) {

            var loja = new Loja { 

                Nome = lojaRegisterDto.Nome,
                Localizacao = lojaRegisterDto.Localizacao,

            };

            await _repositorio.AdicionarAsync(loja);

            return loja;
            
        }

        public async Task<Loja> ObterLoja(int id) {

            var loja = await _repositorio.ObterPorIdAsync(id);          
            return loja;
        }

        public async Task<IEnumerable<Loja>> ObterTodasLojas() {

            var loja = await _repositorio.ObterTodasAsync();
            return loja;
        }

        public async Task<Loja> AtualizarLoja(LojaDto lojaDto) {

            var lojaExistente = await _repositorio.AtualizarAsync(lojaDto);
           
            return lojaExistente;
        }

        public async Task<Loja> DeletarLoja(int id) {
            
            var loja = await _repositorio.DeletarAsync(id);
            return loja;
        }

    }
}
