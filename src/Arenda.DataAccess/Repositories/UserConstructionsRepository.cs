using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Repositories
{
    public class UserConstructionsRepository : IUserConstructionsRepository
    {
        private readonly DbSet<UserConstruction> _entities;

        public UserConstructionsRepository(DbSet<UserConstruction> entities)
        {
            _entities = entities;
        }

        public void Create(UserConstruction entity)
        {
            _entities.Add(entity);
        }
    }
}
