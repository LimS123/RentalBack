using Arenda.BusinessLogic.Contracts;
using Arenda.BusinessLogic.Contracts.Services;
using Arenda.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Arenda.BusinessLogic.Infrastructure.Configurations
{
    public static partial class BusinessLogicConfigurations
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IConstructionService, ConstructionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
