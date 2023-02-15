using Arenda.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Infrastructure.Configurations.DbConfigurations
{
    public static partial class DbConfigurations
    {
        public static ModelBuilder AddEntityConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new ApplicationConfiguration())
                .ApplyConfiguration(new ConstructuionConfiguration())
                .ApplyConfiguration(new ImageConfiguration())
                .ApplyConfiguration(new OrderConfigurations())
                .ApplyConfiguration(new RefreshTokenConfiguration())
                .ApplyConfiguration(new RoleConfiguration())
                .ApplyConfiguration(new UserApplicationConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new UserConstructuionConfiguration())
                .ApplyConfiguration(new UserOrderConfiguration())
                .ApplyConfiguration(new UserRoleConfiguration());

            return modelBuilder;
        }
    }
}
