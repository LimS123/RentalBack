using Arenda.DataAccess.Entities;

namespace Arenda.DataAccess.Contracts.Repositories
{
    public interface IUserRolesRepository
    {
        void Create(UserRole userRole);
        void Update(UserRole userRole);
        void Delete(UserRole userRole);
    }
}
