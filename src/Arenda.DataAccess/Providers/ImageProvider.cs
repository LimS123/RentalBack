using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Providers
{
    public class ImageProvider : IImageProvider
    {
        private readonly DbSet<Image> _entities;

        public ImageProvider(DbSet<Image> entities)
        {
            _entities = entities;
        }

        public Task<Image?> GetById(Guid id, CancellationToken token)
        {
            var result = _entities
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id, token);

            return result;
        }

        public Task<List<Image>> GetAllByConstructionId(Guid constructionId, CancellationToken token)
        {
            var result = _entities
                .Where(x => x.ConstructionId == constructionId)
                .ToListAsync(token);

            return result;
        }
    }
}
