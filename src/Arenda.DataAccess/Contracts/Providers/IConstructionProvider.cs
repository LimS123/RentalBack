using Arenda.DataAccess.Entities;
using Arenda.DataAccess.Models;

namespace Arenda.DataAccess.Contracts.Providers
{
    public interface IConstructionProvider
    {
        Task<Construction?> GetById(Guid id, CancellationToken token);

        Task<Construction?> GetByIdIncludeUserConstructions(Guid id, CancellationToken token);

        Task<bool> HasAnyById(Guid id, CancellationToken token);

        Task<List<Construction>> GetAll(int page, int size, CancellationToken token);

        Task<List<Construction>> GetAllByFilter(ConstructionFilter filter, int page, int size, CancellationToken token);
    }
}
