using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Infrastructure.ContextFactory
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseNpgsql("Host=localhost; Port=8080; Database=ArendaDb; User Id=postgres; Password=postgres");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
