using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Providers
{
    public interface IUserApplicationsProvider
    {
        public Task<Guid> GetUserIdByApplicationId(Guid applicationId, CancellationToken token);
    }
}
