using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Providers
{
    public class RoleProvider : IRoleProvider
    {
        private readonly DbSet<Role> _entities;

        public RoleProvider(DbSet<Role> entities)
        {
            _entities = entities;
        }

        public Task<Role?> GetById(Guid id, CancellationToken token)
        {
            var result = _entities.FirstOrDefaultAsync(e => e.Id == id, token);

            return result;
        }

        public Task<bool> HasAnyById(Guid id, CancellationToken token)
        {
            var result = _entities.AnyAsync(x => x.Id == id, token);

            return result;
        }

        public Task<Role?> GetByType(RoleType type, CancellationToken token)
        {
            var result = _entities.FirstOrDefaultAsync(x => x.Type == type, token);

            return result;
        }
    }
}
