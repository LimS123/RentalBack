using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Repositories
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly DbSet<UserRole> _entities;

        public UserRolesRepository(DbSet<UserRole> entities)
        {
            _entities = entities;
        }

        public void Create(UserRole userRole)
        {
            _entities.Add(userRole);
        }

        public void Update(UserRole userRole)
        {
            _entities.Update(userRole);
        }

        public void Delete(UserRole userRole)
        {
            _entities.Remove(userRole);
        }
    }
}
