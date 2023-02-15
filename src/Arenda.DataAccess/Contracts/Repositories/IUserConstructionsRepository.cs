using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Repositories
{
    public interface IUserConstructionsRepository
    {
        void Create(UserConstruction entity);
    }
}
