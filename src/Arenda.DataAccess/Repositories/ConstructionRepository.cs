using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Repositories
{
    public class ConstructionRepository : IConstructionRepository
    {
        private readonly DbSet<Construction> _entities;

        public ConstructionRepository(DbSet<Construction> entities)
        {
            _entities = entities;
        }

        public void Create(Construction entity)
        {
            _entities.Add(entity);
        }

        public void Update(Construction entity)
        {
            _entities.Update(entity);
        }

        public void Delete(Construction entity)
        {
            _entities.Remove(entity);
        }
    }
}
