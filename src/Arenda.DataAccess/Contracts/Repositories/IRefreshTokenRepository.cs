using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Repositories
{
    public interface IRefreshTokenRepository
    {
        void Create(UserRefreshToken entity);

        void Update(UserRefreshToken entity);

        void Delete(UserRefreshToken entity);
    }
}
