using Microsoft.EntityFrameworkCore;
using Veiculos.Infra.Data;

namespace VeiculosAPI.Extensions {
    static class SqlExtensions {

        public static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<VehiclesContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConection")));

            return services;

        }

    }
}
