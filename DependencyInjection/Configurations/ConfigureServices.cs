using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace DependencyInjection.Configurations
{
    public static class ConfigureServices
    {
        public static void InjectServices(IServiceCollection services) 
        {
            services.AddScoped<ILiberacaoCreditoService, LiberacaoCreditoService>();
        }
    }
}
