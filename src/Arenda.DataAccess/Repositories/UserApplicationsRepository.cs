using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arenda.DataAccess.Repositories
{
    public class UserApplicationsRepository : IUserApplicationsRepository
    {
        private readonly DbSet<UserApplication> _entities;

        public UserApplicationsRepository(DbSet<UserApplication> entities)
        {
            _entities = entities;
        }

        public void Create(UserApplication entity)
        {
            _entities.Add(entity);
        }

        public void Update(UserApplication entity)
        {
            _entities.Update(entity);
        }

        public void Delete(UserApplication entity)
        {
            _entities.Remove(entity);
        }
    }
}
