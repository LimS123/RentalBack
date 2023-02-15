using Arenda.DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Arenda.DataAccess.Infrastructure.Configurations.DbConfigurations
{
    public static partial class DbConfigurations
    {
        public static IServiceCollection AddEntities(this IServiceCollection services)
        {
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<Application>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<Construction>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<UserApplication>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<Image>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<Order>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<Role>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<User>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<UserApplication>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<UserConstruction>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<UserOrder>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<UserRefreshToken>());
            services.AddScoped(_ => _.GetRequiredService<DatabaseContext>().Set<UserRole>());

            return services;
        }
    }
}
