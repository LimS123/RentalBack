using Arenda.BusinessLogic.Contracts.Providers;
using Arenda.BusinessLogic.Contracts.Services;
using Arenda.DataAccess.Contracts;
using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;

namespace Arenda.BusinessLogic.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationProvider _applicationProvider;
        private readonly IUserRolesProvider _userRolesProvider;
        private readonly IUserProvider _userProvider;
        private readonly IRoleProvider _roleProvider;
        private readonly IHttpContextProvider _httpContextProvider;
        private readonly IUserApplicationsProvider _userApplicationsProvider;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUserApplicationsRepository _userApplicationsRepository;
        private readonly IUserRolesRepository _userRolesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDataContext _dataContext;

        public ApplicationService(
            IApplicationProvider applicationProvider,
            IUserRolesProvider userRolesProvider,
            IUserProvider userProvider,
            IRoleProvider roleProvider,
            IHttpContextProvider httpContextProvider,
            IUserApplicationsProvider userApplicationsProvider,
            IDateTimeProvider dateTimeProvider,
            IApplicationRepository applicationRepository,
            IUserApplicationsRepository userApplicationsRepository,
            IUserRolesRepository userRolesRepository,
            IUserRepository userRepository,
            IDataContext dataContext)
        {
            _applicationProvider = applicationProvider;
            _userRolesProvider = userRolesProvider;
            _userProvider = userProvider;
            _roleProvider = roleProvider;
            _httpContextProvider = httpContextProvider;
            _userApplicationsProvider = userApplicationsProvider;
            _dateTimeProvider = dateTimeProvider;
            _applicationRepository = applicationRepository;
            _userApplicationsRepository = userApplicationsRepository;
            _userRolesRepository = userRolesRepository;
            _userRepository = userRepository;
            _dataContext = dataContext;
        }

        public async Task<Models.Application> ApproveApplication(Guid applicationId, CancellationToken token)
        {
            var hasAnyById = await _applicationProvider.HasAnyById(applicationId, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("Application doesn't exist");
            }
            var application = await _applicationProvider.GetById(applicationId, token);

            application.Status = true;
            application.ApprovedAtUtc = _dateTimeProvider.NowUtc;

            _applicationRepository.Update(application);

            var userId = await _userApplicationsProvider.GetUserIdByApplicationId(applicationId, token);
            var user = await _userProvider.GetByIdIncludeUserRoles(userId, token);
            var role = await _roleProvider.GetByType(RoleType.Landlord, token);

            var userRole = await _userRolesProvider.GetUserRoleByUserId(userId, token);

            _userRolesRepository.Delete(userRole);

            user.UserRoles.Add(new UserRole()
            {
                RoleId = role!.Id
            });

            await _dataContext.SaveChanges(token);

            var result = new Models.Application()
            {
                Id = application.Id,
                Title = application.Title,
                Status = application.Status,
                CreatedAtUtc = application.CreatedAtUtc,
                ApprovedAtUtc = application.ApprovedAtUtc.Value
            };

            return result;
        }

        public async Task CreateApplication(CancellationToken token)
        {
            var userId = _httpContextProvider.GetUserId();
            var hasAnyById = await _userProvider.HasAnyById(userId, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("User doesn't exist");
            }
            var user = await _userProvider.GetById(userId, token);

            var application = new Application();

            _applicationRepository.Create(application);
            _userApplicationsRepository.Create(new UserApplication() { Application = application, User = user });

            await _dataContext.SaveChanges(token);
        }

        public async Task<List<Models.Application>> GetAllApplications(int page, int size, CancellationToken token)
        {
            var applications = await _applicationProvider.GetAll(page, size, token);

            var result = new List<Models.Application>();

            foreach(var application in applications)
            {
                var resultApplication = new Models.Application()
                {
                    Id = application.Id,
                    Title = application.Title,
                    Status = application.Status,
                    CreatedAtUtc = application.CreatedAtUtc,
                    ApprovedAtUtc = application.ApprovedAtUtc
                };

                result.Add(resultApplication);
            }

            return result;
        }
    }
}
