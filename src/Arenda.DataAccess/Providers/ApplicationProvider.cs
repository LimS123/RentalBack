using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Providers
{
    public class ApplicationProvider : IApplicationProvider
    {
        private readonly DbSet<Application> _entities;

        public ApplicationProvider(DbSet<Application> entities)
        {
            _entities = entities;
        }

        public Task<Application?> GetById(Guid id, CancellationToken token)
        {
            var result = _entities.FirstOrDefaultAsync(e => e.Id == id, token);

            return result;
        }

        public Task<bool> HasAnyById(Guid id, CancellationToken token)
        {
            var result = _entities.AnyAsync(x => x.Id == id, token);

            return result;
        }

        public Task<List<Application>> GetAll(int page, int size, CancellationToken token)
        {
            var result = _entities
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(token);

            return result;
        }
    }
}
