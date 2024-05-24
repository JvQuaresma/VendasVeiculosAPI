using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Repositories {
    public class LojaRepositorio : ILojaRepository {

        private readonly VendasVeiculoContext _context;
        public LojaRepositorio(VendasVeiculoContext context) {
            _context = context;
        }

        public async Task<Loja> AdicionarAsync(Loja loja) {

            await _context.Lojas.AddAsync(loja);
            await _context.SaveChangesAsync();
            return loja;

        }

        public async Task<Loja> AtualizarAsync(LojaDto lojaDto) {
            try {
                var lojaExistente = await _context.Lojas.FindAsync(lojaDto.Id);

                if (lojaExistente == null)
                    throw new Exception("Loja não encontrada.");

                lojaExistente.Nome = lojaDto.Nome == null ? lojaExistente.Nome : lojaDto.Nome;
                lojaExistente.Localizacao = lojaDto.Localizacao == null ? lojaExistente.Localizacao : lojaDto.Localizacao;
                await _context.SaveChangesAsync();

                return lojaExistente;

            }catch (Exception ex) {

                throw new Exception("Erro ao tentar atualizar" + ex.Message);
            }
        }

        public async Task<Loja> DeletarAsync(int id) {

            try {
                var loja = await _context.Lojas.Include(l => l.Veiculos).FirstOrDefaultAsync(l => l.Id == id);
                _context.Lojas.Remove(loja);
                await _context.SaveChangesAsync();
                return loja;

            } catch (Exception ex) {
                throw new Exception("Erro ao deletar" + ex.Message);
            }

        }

        public async Task<Loja> ObterPorIdAsync(int id) {
            try {
                var loja = await _context.Lojas.Include(l => l.Veiculos).FirstOrDefaultAsync(l => l.Id == id);
                return loja;

            }catch (Exception ex) {
                throw new Exception("Erro ao buscar Id " + ex.Message);
            }
        }

        public async Task<IEnumerable<Loja>> ObterTodasAsync() {

            var loja = await _context.Lojas.Include(v => v.Veiculos).ToListAsync();
            return loja;
        }
    }
}
