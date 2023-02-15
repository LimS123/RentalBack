using Arenda.BusinessLogic.Models;

namespace Arenda.BusinessLogic.Contracts.Services
{
    public interface IApplicationService
    {
        Task CreateApplication(CancellationToken token);
        Task<List<Application>> GetAllApplications(int page, int size, CancellationToken token);
        Task<Application> ApproveApplication(Guid applicationId, CancellationToken token);
    }
}
