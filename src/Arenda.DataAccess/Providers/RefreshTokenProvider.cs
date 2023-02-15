using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Providers
{
    public class RefreshTokenProvider : IRefreshTokenProvider
    {
        private readonly DbSet<UserRefreshToken> _entities;

        public RefreshTokenProvider(DbSet<UserRefreshToken> entities)
        {
            _entities = entities;
        }

        public Task<UserRefreshToken?> GetById(Guid id, CancellationToken token)
        {
            var result = _entities.FirstOrDefaultAsync(e => e.Id == id, token);

            return result;
        }

        public Task<bool> HasAnyById(Guid id, CancellationToken token)
        {
            var result = _entities.AnyAsync(x => x.Id == id, token);

            return result;
        }

        public Task<UserRefreshToken?> GetToken(string refreshToken, CancellationToken token)
        {
            var now = DateTime.UtcNow;
            var result = _entities.FirstOrDefaultAsync(x => x.Token == refreshToken && x.ExpiresAtUtc > now && x.IssuedAtUtc < now, token);

            return result;
        }
    }
}
