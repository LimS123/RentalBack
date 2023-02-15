using Arenda.BusinessLogic.Infrastructure.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Arenda.BusinessLogic.Infrastructure.Configurations
{
    public static partial class BusinessLogicConfigurations
    {
        public static IServiceCollection AddMapProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(x =>
            {
                x.AddProfile<ConstructionFilterProfile>();
            });

            return services;
        }
    }
}
