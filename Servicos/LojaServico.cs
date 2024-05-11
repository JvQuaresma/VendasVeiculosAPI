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

        public Loja AdicionarLoja(LojaDto lojaDto) {

            var loja = new Loja { 

                Nome = lojaDto.Nome,
                Localizacao = lojaDto.Localizacao,

            };

            _context.Lojas.Add(loja);
            _context.SaveChanges();

            return loja;
            
        }

        public Loja ObterLoja(int id) {
            var loja = _context.Lojas.Include(l => l.Veiculos).FirstOrDefault(l => l.Id == id);
            if (loja == null) {
                throw new Exception("Loja não encontrada");
            }

            return loja;
        }

        public IEnumerable<Loja> ObterTodasLojas() {
            return  _context.Lojas.Include(v => v.Veiculos).ToList();
        }

        public void AtualizarLoja(int id, LojaDto lojaDto) {
            var lojaExistente = _context.Lojas.Find(id);

            if (lojaExistente != null) {
                lojaExistente.Nome = lojaDto.Nome;
                lojaExistente.Localizacao = lojaDto.Localizacao;
                _context.SaveChanges();

            } else {

                throw new Exception("Loja não encontrada.");
            }
        }

        public void DeletarLoja(int id) {
            var loja = _context.Lojas.Include(l => l.Veiculos).FirstOrDefault(l => l.Id == id);

            if (loja != null) {
                _context.Veiculos.RemoveRange(loja.Veiculos);
                _context.Lojas.Remove(loja);
                _context.SaveChanges();

            } else {

                throw new Exception("Loja não encontrada.");
            }
        }

    }
}
