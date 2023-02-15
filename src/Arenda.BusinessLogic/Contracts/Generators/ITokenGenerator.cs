using Arenda.BusinessLogic.Models;

namespace Arenda.BusinessLogic.Contracts.Generators
{
    public interface ITokenGenerator
    {
        Task<Token> GenerateToken(DataAccess.Entities.User user, CancellationToken token);
    }
}
