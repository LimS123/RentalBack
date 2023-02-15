using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Repositories
{
    public interface IOrderRepositoty
    {
        void Create(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
    }
}
