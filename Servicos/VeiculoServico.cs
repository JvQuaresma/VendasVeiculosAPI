using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Veiculo> AdicionarVeiculo(VeiculoRegisterDto veiculoRegisterDto) {

            var loja = await _context.Lojas.FindAsync(veiculoRegisterDto.LojaId);
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

            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();

            return veiculo;
            
        }

        public async Task<Veiculo> AtualizarVeiculo(VeiculoDto veiculoDto) {
            var veiculoDb = await _context.Veiculos.FindAsync(veiculoDto.Id);
            if (veiculoDb == null) {

                throw new Exception("Veículo não encontrado");

            }

            var loja = await _context.Lojas.FindAsync(veiculoDto.LojaId);
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

            await _context.SaveChangesAsync();

            return veiculoDb;
           
        }

        public async Task<Veiculo> DeletarVeiculo(int id) {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo != null) {
                throw new Exception("Veículo não encontrado");
            }

           _context.Veiculos.Remove(veiculo);
           await _context.SaveChangesAsync();

            return veiculo;
        }

        public async Task<IEnumerable<Veiculo>> ObterTodosVeiculos(int page) {

            if (page < 1) page = 1;
            int limit = 10;
            int offset = (page - 1) * limit;

            return await _context.Veiculos.Skip(offset).Take(limit).ToListAsync();

        }

        public async Task<Veiculo> ObterVeiculo(int id) {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null) {
                throw new Exception("Veículo não encontrado");
            }

            return veiculo; ;
        }
    }
}
