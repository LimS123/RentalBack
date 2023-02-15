using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepositoty
    {
        private readonly DbSet<Order> _entities;

        public OrderRepository(DbSet<Order> entities)
        {
            _entities = entities;
        }

        public void Create(Order entity)
        {
            _entities.Add(entity);
        }
        public void Update(Order entity)
        {
            _entities.Update(entity);
        }

        public void Delete(Order entity)
        {
            _entities.Remove(entity);
        }
    }
}
