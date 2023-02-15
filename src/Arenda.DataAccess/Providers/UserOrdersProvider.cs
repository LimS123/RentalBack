using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Providers
{
    public class UserOrdersProvider : IUserOrdersProvider
    {
        private readonly DbSet<UserOrder> _entities;

        public UserOrdersProvider(DbSet<UserOrder> entities)
        {
            _entities = entities;
        }

        public Task<List<Order>> GetAllByUserId(Guid userId, CancellationToken token)
        {
            var result = _entities
                .Where(x => x.UserId == userId)
                .Where(x => x.Order.EndedAtUtc > DateTime.UtcNow)
                .Select(x => x.Order)
                .ToListAsync(token);

            return result;
        }

        public Task<Guid> GetConstructionIdByOrderId(Guid orderId, CancellationToken token)
        {
            var result = _entities
                .Where(x => x.OrderId == orderId)
                .Select(x => x.ConstructionId)
                .FirstOrDefaultAsync(token);

            return result;
        }

        public Task<DateTime> GetEndDateOfOrderByConstructionId(Guid constructionId, CancellationToken token)
        {
            var result = _entities
                .Where(x => x.ConstructionId == constructionId)
                .Select(x => x.Order)
                .OrderByDescending(x => x.EndedAtUtc)
                .Select(x => x.EndedAtUtc)
                .FirstOrDefaultAsync(token);

            return result;
        }
    }
}
