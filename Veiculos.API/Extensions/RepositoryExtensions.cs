

using Veiculos.Domain.Interfaces.Repositories;
using Veiculos.Infra.Repositories;

namespace VeiculosAPI.Extensions {
    static class RepositoryExtensions {

        public static IServiceCollection AddRepository(this IServiceCollection services) {

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();

            return services;
        }

    }
}
