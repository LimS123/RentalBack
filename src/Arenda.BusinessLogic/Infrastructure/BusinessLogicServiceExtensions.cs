using Arenda.BusinessLogic.Infrastructure.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace Arenda.BusinessLogic.Infrastructure
{
    public static class BusinessLogicServiceExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddGenerators()
                .AddProviders()
                .AddMapProfiles();

            return services;
        }
    }
}
