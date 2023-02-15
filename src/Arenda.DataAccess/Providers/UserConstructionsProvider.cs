using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Providers
{
    public class UserConstructionsProvider : IUserConstructionsProvider
    {
        private readonly DbSet<UserConstruction> _entities;

        public UserConstructionsProvider(DbSet<UserConstruction> entities)
        {
            _entities = entities;
        }

        public Task<List<Construction>> GetConstructionsByUserId(Guid userId, CancellationToken token)
        {
            var result = _entities
                .Where(x => x.UserId == userId)
                .Include(x => x.Construction).ThenInclude(x => x.Images)
                .Select(x => x.Construction)
                .ToListAsync();

            return result;
        }
    }
}
