using DevIO.Domain.Interfaces;
using DevIO.Domain.Interfaces.Repositories;
using DevIO.Domain.Interfaces.Services;
using DevIO.Domain.Notificacoes;
using DevIO.Domain.Services;
using DevIO.Infra.Repositories;

namespace DevIO.MVC.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
