using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Repositories
{
    public interface IUserRepository
    {
        void Create(User entity);

        void Update(User entity);

        void Delete(User entity);
    }
}
