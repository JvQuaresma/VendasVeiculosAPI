using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Models;

namespace VeiculosAPI.Context {
    public class VendasVeiculoContext : DbContext {

        public VendasVeiculoContext(DbContextOptions options) : base(options) {

        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Loja> Lojas { get; set; }
    }
}
