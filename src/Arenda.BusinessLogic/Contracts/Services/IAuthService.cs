using Arenda.BusinessLogic.Models;

namespace Arenda.BusinessLogic.Contracts
{
    public interface IAuthService
    {
        Task<Token> Authenticate(string email, string password, CancellationToken token);
        Task<Token> Authenticate(string refreshToken, CancellationToken token);
    }
}
