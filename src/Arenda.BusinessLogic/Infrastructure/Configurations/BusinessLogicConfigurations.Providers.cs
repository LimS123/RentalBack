using Arenda.BusinessLogic.Contracts.Providers;
using Arenda.BusinessLogic.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Arenda.BusinessLogic.Infrastructure.Configurations
{
    public static partial class BusinessLogicConfigurations
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IHashProvider, BCryptHashProvider>();
            services.AddScoped<IHttpContextProvider, HttpContextProvider>();

            return services;
        }
    }
}
