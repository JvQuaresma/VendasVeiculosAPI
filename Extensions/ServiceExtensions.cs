
using Veiculos.Domain.Interfaces.Services;
using Veiculos.Service.Services;

namespace VeiculosAPI.Extensions {
    static class ServiceExtensions {

        public static IServiceCollection AddService(this IServiceCollection services) {

            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IVehicleService, VehicleService>();

            return services;

        }

    }
}
