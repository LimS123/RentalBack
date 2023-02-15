using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly DbSet<Image> _entities;

        public ImageRepository(DbSet<Image> entities)
        {
            _entities = entities;
        }

        public void Create(Image entity)
        {
            _entities.Add(entity);
        }

        public void Update(Image entity)
        {
            _entities.Update(entity);
        }

        public void Delete(Image entity)
        {
            _entities.Remove(entity);
        }
    }
}
