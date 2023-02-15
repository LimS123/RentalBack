using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Providers
{
    public interface IApplicationProvider
    {
        public Task<Application?> GetById(Guid id, CancellationToken token);
        public Task<bool> HasAnyById(Guid id, CancellationToken token);
        public Task<List<Application>> GetAll(int page, int size, CancellationToken token);
    }
}
