using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Arenda.DataAccess.Infrastructure.Configurations.DataAccessConfigurations
{
    public static partial class DataAccessConfigurations
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IApplicationProvider, ApplicationProvider>();
            services.AddScoped<IConstructionProvider, ConstructionProvider>();
            services.AddScoped<IImageProvider, ImageProvider>();
            services.AddScoped<IRefreshTokenProvider, RefreshTokenProvider>();
            services.AddScoped<IRoleProvider, RoleProvider>();
            services.AddScoped<IUserApplicationsProvider, UserApplicationsProvider>();
            services.AddScoped<IUserConstructionsProvider, UserConstructionsProvider>();
            services.AddScoped<IUserOrdersProvider, UserOrdersProvider>();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IUserRolesProvider, UserRolesProvider>();

            return services;
        }
    }

}
