using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Repositories
{
    public interface IUserApplicationsRepository
    {
        public void Create(UserApplication entity);
        public void Update(UserApplication entity);
        public void Delete(UserApplication entity);
    }
}
