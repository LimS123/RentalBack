using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Providers
{
    public interface IRoleProvider
    {
        Task<Role?> GetById(Guid id, CancellationToken token);

        Task<bool> HasAnyById(Guid id, CancellationToken token);

        Task<Role?> GetByType(RoleType type, CancellationToken token);
    }
}
