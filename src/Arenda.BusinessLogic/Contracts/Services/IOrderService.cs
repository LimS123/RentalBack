using Arenda.BusinessLogic.Models;

namespace Arenda.BusinessLogic.Contracts.Services
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrder create, CancellationToken token);
        Task<List<Order>> GetAllOrders(Guid userId, CancellationToken token);
        Task<DateTime> GetEndDateOfOrder(Guid constructionId, CancellationToken token);
    }
}
