using Arenda.BusinessLogic.Models;

namespace Arenda.BusinessLogic.Contracts
{
    public interface IConstructionService
    {
        Task<Construction> CreateConstruction(CreateConstruction createConstruction, CancellationToken token);
        Task<Construction> UpdateConstruciton(UpdateConstruction updateConstruction, CancellationToken token);
        Task RemoveConstruciton(Guid constructionId, CancellationToken token);
        Task<Construction> GetConstruction(Guid constructionId, CancellationToken token);
        Task<List<Construction>> GetAllConstructions(int page, int size, CancellationToken token);
        Task<List<Construction>> GetAllConstructionsByUserId(Guid userId, CancellationToken token);
        Task<List<Construction>> GetAllConstructionsByFilter(ConstructionFilter constructionFilter, int page, int size, CancellationToken token);
    }
}
