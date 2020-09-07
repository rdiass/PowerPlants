using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PowerPlants.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ResolveSwagger(this IServiceCollection services)
        {
            var info = new OpenApiInfo()
            {
                Title = "API - PowerPlants",
                Version = "v1",
                Description = "This API is to calculate how much power each of a multitude of different powerplants need to produce (a.k.a. the production-plan).",
                Contact = new OpenApiContact() { Name = "Rafael Santos", Email = "rafaeldias.a@hotmail.com" }
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", info);
            });

            return services;
        }
    }
}