using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Repositories
{
    public interface IApplicationRepository
    {
        void Create(Application entity);

        void Update(Application entity);

        void Delete(Application entity);
    }
}
