using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Repositories
{
    public interface IImageRepository
    {
        void Create(Image entity);

        void Update(Image entity);

        void Delete(Image entity);
    }
}
