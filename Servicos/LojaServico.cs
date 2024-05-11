using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Servicos {
    public class LojaServico : ILojaServico {

        private readonly VendasVeiculoContext _context;

        public LojaServico(VendasVeiculoContext context) {

            _context = context;

        }

        public async Task<Loja> AdicionarLoja(LojaRegisterDto lojaRegisterDto) {

            var loja = new Loja { 

                Nome = lojaRegisterDto.Nome,
                Localizacao = lojaRegisterDto.Localizacao,

            };

           await _context.Lojas.AddAsync(loja);
           await _context.SaveChangesAsync();

            return loja;
            
        }

        public async Task<Loja> ObterLoja(int id) {
            var loja = await _context.Lojas.Include(l => l.Veiculos).FirstOrDefaultAsync(l => l.Id == id);
            if (loja == null) {
                throw new Exception("Loja não encontrada");
            }

            return loja;
        }

        public async Task<IEnumerable<Loja>> ObterTodasLojas() {
            return  await _context.Lojas.Include(v => v.Veiculos).ToListAsync();
        }

        public async Task<Loja> AtualizarLoja(LojaDto lojaDto) {
            var lojaExistente = await _context.Lojas.FindAsync(lojaDto.Id);

            if (lojaExistente != null) {
                lojaExistente.Nome = lojaDto.Nome == null ? lojaExistente.Nome : lojaDto.Nome;
                lojaExistente.Localizacao = lojaDto.Localizacao == null ? lojaExistente.Localizacao : lojaDto.Localizacao; 
                await _context.SaveChangesAsync();

            } else {

                throw new Exception("Loja não encontrada.");
            }

            return lojaExistente;
        }

        public async Task<Loja> DeletarLoja(int id) {
            var loja = await _context.Lojas.Include(l => l.Veiculos).FirstOrDefaultAsync(l => l.Id == id);

            if (loja != null) {
               _context.Veiculos.RemoveRange(loja.Veiculos);
               _context.Lojas.Remove(loja);
               await _context.SaveChangesAsync();

            } else {

                throw new Exception("Loja não encontrada.");
            }

            return loja;
        }

    }
}
