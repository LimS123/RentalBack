using Arenda.BusinessLogic.Contracts;
using Arenda.BusinessLogic.Contracts.Providers;
using Arenda.DataAccess.Contracts;
using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;

namespace Arenda.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserProvider _userProvider;
        private readonly IRoleProvider _roleProvider;
        private readonly IUserRolesProvider _userRolesProvider;
        private readonly IHashProvider _hashProvider;
        private readonly IHttpContextProvider _httpContextProvider;
        private readonly IUserRepository _userRepository;
        private readonly IDataContext _dataContext;

        public UserService(
            IUserProvider userProvider,
            IRoleProvider roleProvider,
            IUserRolesProvider userRolesProvider,
            IHashProvider hashProvider,
            IHttpContextProvider httpContextProvider,
            IUserRepository userRepository,
            IDataContext dataContext)
        {
            _userProvider = userProvider;
            _roleProvider = roleProvider;
            _userRolesProvider = userRolesProvider;
            _hashProvider = hashProvider;
            _httpContextProvider = httpContextProvider;
            _userRepository = userRepository;
            _dataContext = dataContext;
        }

        public async Task<Models.User> CreateUser(Models.CreateUser createUser, CancellationToken token)
        {
            var user = new User()
            {
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                Email = createUser.Email,
                PasswordHash = _hashProvider.Hash(createUser.Password),
                PhoneNumber = createUser.PhoneNumber
            };

            _userRepository.Create(user);

            var userRole = await _roleProvider.GetByType(RoleType.User, token);

            user.UserRoles.Add(new UserRole()
            {
                RoleId = userRole!.Id
            });

            await _dataContext.SaveChanges(token);

            var role = await _userRolesProvider.GetUserRoleByUserIdWithIncludeRole(user.Id, token);

            var newUser = new Models.User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = RoleToString(role!.Role.Type)
            };

            return newUser;
        }

        public async Task<Models.User> GetCurrentUser(CancellationToken token)
        {
            var userId = _httpContextProvider.GetUserId();
            var hasAnyById = await _userProvider.HasAnyById(userId, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("User doesn't exist");
            }

            var user = await _userProvider.GetById(userId, token);
            var role = await _userRolesProvider.GetRoleByUserId(userId, token);

            var result = new Models.User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = RoleToString(role!.Type)
            };

            return result;
        }

        public async Task<Models.User> GetUser(Guid userId, CancellationToken token)
        {
            var hasAnyById = await _userProvider.HasAnyById(userId, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("User doesn't exist");
            }

            var user = await _userProvider.GetById(userId, token);
            var role = await _userRolesProvider.GetRoleByUserId(userId, token);

            var result = new Models.User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = RoleToString(role!.Type)
            };

            return result;
        }

        public async Task<Models.User> UpdateUser(Models.UpdateUser updateUser, CancellationToken token)
        {
            var hasAnyById = await _userProvider.HasAnyById(updateUser.UserId, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("User doesn't exist");
            }

            var user = await _userProvider.GetById(updateUser.UserId, token);

            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.PhoneNumber = updateUser.PhoneNumber;

            _userRepository.Update(user);
            await _dataContext.SaveChanges(token);

            var role = await _userRolesProvider.GetUserRoleByUserIdWithIncludeRole(user.Id, token);

            var newUser = new Models.User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = RoleToString(role!.Role.Type)
            };

            return newUser;
        }

        private string RoleToString(RoleType type) => type switch
        {
            RoleType.User => "User",
            RoleType.Landlord => "Landlord",
            RoleType.Administrator => "Administrator",
            RoleType.Unspecified => throw new ArgumentException(nameof(type), $"Not found role: {type}"),
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected direction value: {type}"),
        };
    }
}
