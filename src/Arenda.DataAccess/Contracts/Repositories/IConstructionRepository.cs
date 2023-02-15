using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Repositories
{
    public interface IConstructionRepository
    {
        void Create(Construction entity);

        void Update(Construction entity);

        void Delete(Construction entity);
    }
}
