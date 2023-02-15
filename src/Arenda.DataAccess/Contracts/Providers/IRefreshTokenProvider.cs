using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Providers
{
    public interface IRefreshTokenProvider
    {
        Task<UserRefreshToken?> GetById(Guid id, CancellationToken token);

        Task<bool> HasAnyById(Guid id, CancellationToken token);

        Task<UserRefreshToken?> GetToken(string refreshToken, CancellationToken token);
    }
}
