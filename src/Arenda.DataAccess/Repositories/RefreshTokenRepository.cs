using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly DbSet<UserRefreshToken> _entities;

        public RefreshTokenRepository(DbSet<UserRefreshToken> entities)
        {
            _entities = entities;
        }

        public void Create(UserRefreshToken entity)
        {
            _entities.Add(entity);
        }

        public void Update(UserRefreshToken entity)
        {
            _entities.Update(entity);
        }

        public void Delete(UserRefreshToken entity)
        {
            _entities.Remove(entity);
        }
    }
}
