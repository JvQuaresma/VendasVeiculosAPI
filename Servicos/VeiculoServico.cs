using VeiculosAPI.Context;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;
using VeiculosAPI.Servicos.Interfaces;

namespace VeiculosAPI.Servicos {
    public class VeiculoServico : IVeiculoServico {

        private readonly VendasVeiculoContext _context;

        public VeiculoServico(VendasVeiculoContext context) {

            _context = context;

        }

        public Veiculo AdicionarVeiculo(VeiculoDto veiculoDto) {

            var loja = _context.Lojas.Find(veiculoDto.LojaId);
            if (loja == null) {
                throw new Exception("Loja não encontrada");
            }

            var veiculo = new Veiculo { 

                Modelo = veiculoDto.Modelo,
                Marca = veiculoDto.Marca,
                Ano = veiculoDto.Ano,
                Preco = veiculoDto.Preco,
                LojaId = veiculoDto.LojaId,
                Loja = loja,
                Vendido = false
            };

            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();

            return veiculo;
            
        }

        public void AtualizarVeiculo(int id, VeiculoDto veiculoDto) {
            var veiculoDb = _context.Veiculos.Find(id);
            if (veiculoDb != null) {

                var loja = _context.Lojas.Find(veiculoDto.LojaId);
                if (loja == null) {
                    throw new Exception("Loja não encontrada");

                }

                veiculoDb.Modelo = veiculoDto.Modelo;
                veiculoDb.Marca = veiculoDto.Marca;
                veiculoDb.Ano = veiculoDto.Ano;
                veiculoDb.Preco = veiculoDto.Preco;
                veiculoDb.LojaId = veiculoDto.LojaId;
                veiculoDb.Loja = loja;

                _context.SaveChanges();

            }
            

        }

        public void DeletarVeiculo(int id) {
            var veiculo = _context.Veiculos.Find(id);
            if (veiculo != null) {
                throw new Exception("Veículo não encontrado");
            }

            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();

        }

        public IEnumerable<Veiculo> ObterTodosVeiculos(int page) {

            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;

            return _context.Veiculos.Skip(offset).Take(limit).ToList();

        }

        public Veiculo ObterVeiculo(int id) {
            var veiculo = _context.Veiculos.Find(id);
            if (veiculo == null) {
                throw new Exception("Veículo não encontrado");
            }

            return veiculo; ;
        }
    }
}
