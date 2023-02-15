using Arenda.BusinessLogic.Contracts.Generators;
using Arenda.BusinessLogic.Generators;
using Microsoft.Extensions.DependencyInjection;

namespace Arenda.BusinessLogic.Infrastructure.Configurations
{
    public static partial class BusinessLogicConfigurations
    {
        public static IServiceCollection AddGenerators(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();

            return services;
        }
    }
}
