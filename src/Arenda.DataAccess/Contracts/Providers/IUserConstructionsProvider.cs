using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Providers
{
    public interface IUserConstructionsProvider
    {
        Task<List<Construction>> GetConstructionsByUserId(Guid userId, CancellationToken token);
    }
}
