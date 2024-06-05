using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VeiculosAPI.Context;
using VeiculosAPI.DTOs;
using VeiculosAPI.Models;
using VeiculosAPI.Repositories.Interfaces;

namespace VeiculosAPI.Repositories
{
    public class VeiculoRepositorio : IVeiculoRepository {

        private readonly VendasVeiculoContext _context;

        public VeiculoRepositorio(VendasVeiculoContext context) {
            _context = context;
        }

        public async Task<Veiculo> AdicionarAsync(Veiculo veiculo) {

            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
            return veiculo;

        }

        public async Task<Veiculo> AtualizarAsync(Veiculo veiculo) {
            try {
                var veiculoDb = await _context.Veiculos.FindAsync(veiculo.Id);
                if (veiculoDb == null) {

                    throw new Exception("Veículo não encontrado");

                }

                var loja = await _context.Lojas.FindAsync(veiculo.LojaId);
                if (loja == null) {

                    throw new Exception("Loja não encontrada");

                }

                
                await _context.SaveChangesAsync();

                return veiculoDb;

            } catch (Exception ex) {
                throw new Exception("Erro ao atualizar" + ex.Message);
            }
        }

        public async Task<Veiculo> DeletarAsync(int id) {

            try {
                var veiculo = await _context.Veiculos.FindAsync(id);
                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();
                return veiculo;

            }catch(Exception ex) {
                throw new Exception("Erro ao deletar" + ex.Message);
            }
                      
        }

        public async Task<Veiculo> ObterPorIdAsync(int id) {

           return await _context.Veiculos.FindAsync(id);

        }

        public async Task<IEnumerable<Veiculo>> ObterTodosAsync(int page, int limit, int offset) {
           
            var resultado = await _context.Veiculos.Skip(offset).Take(limit).ToListAsync();
            return resultado;

        }
    }
}
