using Arenda.BusinessLogic.Models;

namespace Arenda.BusinessLogic.Contracts
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUser createUser, CancellationToken token);
        Task<User> UpdateUser(UpdateUser updateUser, CancellationToken token);
        Task<User> GetUser(Guid userId, CancellationToken token);
        Task<User> GetCurrentUser(CancellationToken token);
    }
}
