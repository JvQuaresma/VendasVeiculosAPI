using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Servicos {
    public class VendaServico : IVendaServico {

        private readonly VendasVeiculoContext _context;
        private readonly IVendaRepository _repositorio;

        public VendaServico(VendasVeiculoContext context, IVendaRepository repositorio) {

            _context = context;
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Venda>> ObterTodasVendas(int page) {

            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;

            var resultado = await _repositorio.ObterTodasAsync(page, limit, offset);
            return resultado;
        }

        public async Task<Venda> ObterVenda(int id) {

            var venda = await _repositorio.ObterPorIdAsync(id);         
            return venda;
            
        }

        public async Task<Venda> VenderVeiculo(VendaDto vendaDto) {

            var venda = await _repositorio.VenderAsync(vendaDto);

            return venda;

        }
    }
}
