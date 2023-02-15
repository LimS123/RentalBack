using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arenda.DataAccess.Providers
{
    public class UserApplicationsProvider : IUserApplicationsProvider
    {
        private readonly DbSet<UserApplication> _entities;

        public UserApplicationsProvider(DbSet<UserApplication> entities)
        {
            _entities = entities;
        }

        public Task<Guid> GetUserIdByApplicationId(Guid applicationId, CancellationToken token)
        {
            var result = _entities
                .Where(x => x.ApplicationId == applicationId)
                .Select(x => x.User.Id)
                .FirstOrDefaultAsync(token);

            return result;
        }
    }
}
