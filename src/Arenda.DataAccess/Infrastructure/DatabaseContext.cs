using Arenda.DataAccess.Infrastructure.Configurations.DbConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfigurations();

            base.OnModelCreating(modelBuilder);
        }
    }
}
