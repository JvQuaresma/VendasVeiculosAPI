using VeiculosAPI.Repositories.Interfaces;
using VeiculosAPI.Repositories;

namespace VeiculosAPI.Extensions {
    static class RepositoryExtensions {

        public static IServiceCollection AddRepository(this IServiceCollection services) {

            services.AddScoped<IVeiculoRepository, VeiculoRepositorio>();
            services.AddScoped<ILojaRepository, LojaRepositorio>();
            services.AddScoped<IVendaRepository, VendaRepositorio>();

            return services;
        }

    }
}
