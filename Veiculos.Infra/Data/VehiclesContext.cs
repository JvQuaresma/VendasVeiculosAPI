using Microsoft.EntityFrameworkCore;
using Veiculos.Domain.Models;

namespace Veiculos.Infra.Data {
    public class VehiclesContext : DbContext {

        public VehiclesContext(DbContextOptions options) : base(options) {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
