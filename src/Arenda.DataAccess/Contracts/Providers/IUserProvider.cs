using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Providers
{
    public interface IUserProvider
    {
        Task<User?> GetById(Guid id, CancellationToken token);
        Task<User?> GetByIdIncludeUserRoles(Guid id, CancellationToken token);
        Task<bool> HasAnyById(Guid id, CancellationToken token);
        Task<User?> GetByEmail(string email, CancellationToken token);
        Task<bool> HasAnyByEmail(string email, CancellationToken token);
    }
}
