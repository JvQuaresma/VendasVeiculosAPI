using Microsoft.EntityFrameworkCore;
using VeiculosAPI.Context;

namespace VeiculosAPI.Extensions {
    static class SqlExtensions {

        public static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<VendasVeiculoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConexaoPadrao")));

            return services;

        }

    }
}
