using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _entities;

        public UserRepository(DbSet<User> entities)
        {
            _entities = entities;
        }

        public void Create(User entity)
        {
            _entities.Add(entity);
        }

        public void Update(User entity)
        {
            _entities.Update(entity);
        }

        public void Delete(User entity)
        {
            _entities.Remove(entity);
        }
    }
}
