using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly DbSet<User> _entities;

        public UserProvider(DbSet<User> enities)
        {
            _entities = enities;
        }

        public Task<User?> GetById(Guid id, CancellationToken token)
        {
            var result = _entities.FirstOrDefaultAsync(e => e.Id == id, token);

            return result;
        }

        public Task<User?> GetByIdIncludeUserRoles(Guid id, CancellationToken token)
        {
            var result = _entities
                .Include(x => x.UserRoles)
                .FirstOrDefaultAsync(e => e.Id == id, token);

            return result;
        }

        public Task<bool> HasAnyById(Guid id, CancellationToken token)
        {
            var result = _entities.AnyAsync(x => x.Id == id, token);

            return result;
        }

        public Task<User?> GetByEmail(string email, CancellationToken token)
        {
            var result = _entities.FirstOrDefaultAsync(e => e.Email == email, token);

            return result;
        }

        public Task<bool> HasAnyByEmail(string email, CancellationToken token)
        {
            var result = _entities.AnyAsync(x => x.Email == email, token);

            return result;
        }
    }
}
