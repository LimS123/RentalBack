using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Entities;
using Arenda.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Providers
{
    public class ConstructionProvider : IConstructionProvider
    {
        private readonly DbSet<Construction> _entities;

        public ConstructionProvider(DbSet<Construction> entities)
        {
            _entities = entities;
        }

        public Task<Construction?> GetById(Guid id, CancellationToken token)
        {
            var result = _entities
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Include(x => x.Images)
                .FirstOrDefaultAsync(token);

            return result;
        }

        public Task<bool> HasAnyById(Guid id, CancellationToken token)
        {
            var result = _entities.AnyAsync(x => x.Id == id, token);

            return result;
        }

        public Task<List<Construction>> GetAll(int page, int size, CancellationToken token)
        {
            var result = _entities
                .Include(x => x.Images)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(token);

            return result;
        }

        public Task<List<Construction>> GetAllByFilter(ConstructionFilter filter, int page, int size, CancellationToken token)
        {
            var query = _entities
                .AsQueryable();

            if (filter.MaxCost.HasValue)
            {
                query = query.Where(x => x.Price <= filter.MaxCost.Value);
            }

            if (filter.MinCost.HasValue)
            {
                query = query.Where(x => x.Price >= filter.MinCost.Value);
            }

            if (filter.CreatedAtUtcOrder.HasValue)
            {
                query = query.OrderBy(x => x.CreatedAtUtc);
            }
            else if (filter.CreatedAtUtcOrder.HasValue is false)
            {
                query = query.OrderByDescending(x => x.CreatedAtUtc);
            }

            if (filter.Type.HasValue && filter.Type.Value != ConstructionType.Unspecified)
            {
                query = query.Where(x => x.Type == filter.Type);
            }

            if (filter.MaxSquare.HasValue)
            {
                query = query.Where(x => x.Square <= filter.MaxSquare.Value);
            }

            if (filter.MinSquare.HasValue)
            {
                query = query.Where(x => x.Square >= filter.MinSquare.Value);
            }

            if (filter.MaxYear.HasValue)
            {
                query = query.Where(x => x.Year <= filter.MaxYear.Value);
            }

            if (filter.MinYear.HasValue)
            {
                query = query.Where(x => x.Year >= filter.MinYear.Value);
            }

            if (filter.NumberOfRooms.HasValue)
            {
                query = query.Where(x => x.NumberOfRooms == filter.NumberOfRooms.Value);
            }

            if (filter.Floor.HasValue)
            {
                query = query.Where(x => x.Floor == filter.Floor.Value);
            }

            var result = query
                .Include(x => x.Images)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(token);

            return result;
        }

        public Task<Construction?> GetByIdIncludeUserConstructions(Guid id, CancellationToken token)
        {
            var result = _entities
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Include(x => x.Images)
                .Include(x => x.UserConstructions)
                .FirstOrDefaultAsync(token);

            return result;
        }
    }
}
