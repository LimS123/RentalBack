using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Providers
{
    public interface IUserRolesProvider
    {
        Task<Role?> GetRoleByUserId(Guid userId, CancellationToken token);
        Task<UserRole?> GetUserRoleByUserId(Guid userId, CancellationToken token);
        Task<UserRole?> GetUserRoleByUserIdWithIncludeRole(Guid userId, CancellationToken token);
    }
}
