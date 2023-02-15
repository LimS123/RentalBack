using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Providers
{
    public interface IUserOrdersProvider
    {
        Task<List<Order>> GetAllByUserId(Guid userId, CancellationToken token);
        Task<Guid> GetConstructionIdByOrderId(Guid orderId, CancellationToken token);
        Task<DateTime> GetEndDateOfOrderByConstructionId(Guid constructionId, CancellationToken token);
    }
}
