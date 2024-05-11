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

        public Veiculo AdicionarVeiculo(VeiculoRegisterDto veiculoRegisterDto) {

            var loja = _context.Lojas.Find(veiculoRegisterDto.LojaId);
            if (loja == null) {
                throw new Exception("Loja não encontrada");
            }

            var veiculo = new Veiculo { 

                Modelo = veiculoRegisterDto.Modelo,
                Marca = veiculoRegisterDto.Marca,
                Ano = veiculoRegisterDto.Ano,
                Preco = veiculoRegisterDto.Preco,
                LojaId = veiculoRegisterDto.LojaId,
                Loja = loja,
                Vendido = false
            };

            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();

            return veiculo;
            
        }

        public void AtualizarVeiculo(VeiculoDto veiculoDto) {
            var veiculoDb = _context.Veiculos.Find(veiculoDto.Id);
            if (veiculoDb != null) {

                var loja = _context.Lojas.Find(veiculoDto.LojaId);
                if (loja == null) {
                    throw new Exception("Loja não encontrada");

                }

                veiculoDb.Modelo = veiculoDto.Modelo == null ? veiculoDb.Modelo : veiculoDto.Modelo;
                veiculoDb.Marca = veiculoDto.Marca == null ? veiculoDb.Marca : veiculoDto.Marca;
                veiculoDb.Ano = veiculoDto.Ano == null ? veiculoDb.Ano : veiculoDto.Ano; 
                veiculoDb.Preco = veiculoDto.Preco == null ? veiculoDb.Preco : veiculoDto.Preco;
                veiculoDb.LojaId = veiculoDto.LojaId;
                veiculoDb.Vendido = veiculoDto.Vendido == null ? veiculoDb.Vendido : veiculoDto.Vendido;
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
