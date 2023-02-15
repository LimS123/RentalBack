using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Arenda.DataAccess.Infrastructure.Configurations.DataAccessConfigurations
{
    public static partial class DataAccessConfigurations
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IConstructionRepository, ConstructionRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IOrderRepositoty, OrderRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserApplicationsRepository, UserApplicationsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOrdersRepository, UserOrdersRepository>();
            services.AddScoped<IUserRolesRepository, UserRolesRepository>();
            services.AddScoped<IUserConstructionsRepository, UserConstructionsRepository>();

            return services;
        }
    }
}
