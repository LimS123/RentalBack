using Arenda.BusinessLogic.Contracts.Providers;
using Arenda.BusinessLogic.Contracts.Services;
using Arenda.DataAccess.Contracts;
using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;

namespace Arenda.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUserOrdersProvider _userOrdersProvider;
        private readonly IHttpContextProvider _httpContextProvider;
        private readonly IUserProvider _userProvider;
        private readonly IConstructionProvider _constructionProvider;
        private readonly IUserOrdersRepository _userOrdersRepository;
        private readonly IOrderRepositoty _orderRepository;
        private readonly IDataContext _dataContext;

        public OrderService(
            IUserOrdersProvider userOrdersProvider,
            IHttpContextProvider httpContextProvider,
            IUserProvider userProvider,
            IConstructionProvider constructionProvider,
            IUserOrdersRepository userOrdersRepository,
            IOrderRepositoty orderRepositoty,
            IDataContext dataContext)
        {
            _userOrdersProvider = userOrdersProvider;
            _httpContextProvider = httpContextProvider;
            _userProvider = userProvider;
            _constructionProvider = constructionProvider;
            _userOrdersRepository = userOrdersRepository;
            _orderRepository = orderRepositoty;
            _dataContext = dataContext;
        }

        public async Task CreateOrder(Models.CreateOrder create, CancellationToken token)
        {
            var userId = _httpContextProvider.GetUserId();
            var hasAnyUserById = await _userProvider.HasAnyById(userId, token);

            if (!hasAnyUserById)
            {
                throw new ApplicationException("User doesn't exist");
            }

            var user = await _userProvider.GetById(userId, token);
            var hasAnyConstructionById = await _constructionProvider.HasAnyById(create.ConstructionId, token);

            if (!hasAnyConstructionById)
            {
                throw new ApplicationException("Construction doesn't exist");
            }

            var construction = await _constructionProvider.GetById(create.ConstructionId, token);

            var order = new Order()
            {
                StartedAtUtc = create.StartedAtUtc,
                EndedAtUtc = create.EndedAtUtc
            };

            _orderRepository.Create(order);
            _userOrdersRepository.Create(new UserOrder() { UserId = userId, ConstructionId = construction!.Id, OrderId = order.Id });
            await _dataContext.SaveChanges(token);
        }

        public async Task<List<Models.Order>> GetAllOrders(Guid userId, CancellationToken token)
        {
            var hasAnyById = await _userProvider.HasAnyById(userId, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("User doesn't exist");
            }

            var user = await _userProvider.GetById(userId, token);
            var orders = await _userOrdersProvider.GetAllByUserId(userId, token);
            var resultOrders = new List<Models.Order>();

            foreach(var order in orders)
            {
                var constructionId = await _userOrdersProvider.GetConstructionIdByOrderId(order.Id, token);
                var resultOrder = new Models.Order()
                {
                    Id = order.Id,
                    ConstructionId = constructionId,
                    StartedAtUtc = order.StartedAtUtc,
                    EndedAtUtc = order.EndedAtUtc
                };

                resultOrders.Add(resultOrder);
            }

            return resultOrders;
        }

        public async Task<DateTime> GetEndDateOfOrder(Guid constructionId, CancellationToken token)
        {
            var hasAnyById = await _constructionProvider.HasAnyById(constructionId, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("Construction doesn't exist");
            }

            var construction = await _constructionProvider.GetById(constructionId, token);

            var endDate = await _userOrdersProvider.GetEndDateOfOrderByConstructionId(constructionId, token);

            return endDate;
        }
    }
}
