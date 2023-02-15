using Arenda.DataAccess.Contracts;
using Arenda.DataAccess.Infrastructure;

namespace Arenda.DataAccess
{
    public class DataContext : IDataContext
    {
        private readonly DatabaseContext _dbContext;

        public DataContext(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task SaveChanges(CancellationToken token)
        {
            return _dbContext.SaveChangesAsync(token);
        }
    }
}
