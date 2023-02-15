using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Providers
{
    public class UserRolesProvider : IUserRolesProvider
    {
        private readonly DbSet<UserRole> _entities;

        public UserRolesProvider(DbSet<UserRole> entities)
        {
            _entities = entities;
        }

        public Task<Role?> GetRoleByUserId(Guid userId, CancellationToken token)
        {
            var result = _entities
                .Where(x => x.UserId == userId)
                .Select(x => x.Role)
                .FirstOrDefaultAsync(token);

            return result;
        }

        public Task<UserRole?> GetUserRoleByUserId(Guid userId, CancellationToken token)
        {
            var result = _entities
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync(token);

            return result;
        }

        public Task<UserRole?> GetUserRoleByUserIdWithIncludeRole(Guid userId, CancellationToken token)
        {
            var result = _entities
                .Where(x => x.UserId == userId)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(token);

            return result;
        }
    }
}
