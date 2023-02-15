using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Repositories
{
    public class UserOrdersRepository : IUserOrdersRepository
    {
        private readonly DbSet<UserOrder> _entities;

        public UserOrdersRepository(DbSet<UserOrder> entities)
        {
            _entities = entities;
        }

        public void Create(UserOrder entity)
        {
            _entities.Add(entity);
        }

        public void Update(UserOrder entity)
        {
            _entities.Update(entity);
        }

        public void Delete(UserOrder entity)
        {
            _entities.Remove(entity);
        }
    }
}
