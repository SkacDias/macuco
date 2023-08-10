using MacucoApi.Interfaces;
using MacucoApi.Repositories;
using MacucoApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MacucoApi.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IFacial_Records_Repository, Facial_Records_Repository>();
            services.AddSingleton<IFacial_Records_Service, Facial_Records_Service>();

            return services;
        }
    }
}