using Arenda.DataAccess.Contracts;
using Arenda.DataAccess.Infrastructure.Configurations.DataAccessConfigurations;
using Arenda.DataAccess.Infrastructure.Configurations.DbConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arenda.DataAccess.Infrastructure
{
    public static class DataAccessServiceExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services
                .AddProviders()
                .AddRepositories();

            return services;
        }

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContextPool<DatabaseContext>(options);
            services.AddScoped<IDataContext, DataContext>();
            services.AddEntities();

            return services;
        }
    }
}
