using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Repositories
{
    public interface IUserOrdersRepository
    {
        void Create(UserOrder entity);
        void Update(UserOrder entity);
        void Delete(UserOrder entity);
    }
}
