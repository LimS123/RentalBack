using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DbSet<Application> _entities;

        public ApplicationRepository(DbSet<Application> entities)
        {
            _entities = entities;
        }

        public void Create(Application entity)
        {
            _entities.Add(entity);
        }

        public void Update(Application entity)
        {
            _entities.Update(entity);
        }

        public void Delete(Application entity)
        {
            _entities.Remove(entity);
        }
    }
}
