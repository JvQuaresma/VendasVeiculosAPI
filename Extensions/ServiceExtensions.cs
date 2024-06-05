using VeiculosAPI.Servicos.Interfaces;
using VeiculosAPI.Servicos;

namespace VeiculosAPI.Extensions {
    static class ServiceExtensions {

        public static IServiceCollection AddService(this IServiceCollection services) {

            services.AddScoped<ILojaServico, LojaServico>();
            services.AddScoped<IVendaServico, VendaServico>();
            services.AddScoped<IVeiculoServico, VeiculoServico>();

            return services;

        }

    }
}
