using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Providers
{
    public interface IImageProvider
    {
        Task<Image?> GetById(Guid id, CancellationToken token);

        Task<List<Image>> GetAllByConstructionId(Guid constructionId, CancellationToken token);
    }
}
