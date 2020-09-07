using PowerPlants.Business.Intefaces;
using PowerPlants.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace PowerPlants.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductionService, ProductionService>();                                            
            return services;
        }
    }
}