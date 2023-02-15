using Arenda.BusinessLogic.Contracts;
using Arenda.BusinessLogic.Contracts.Services;
using Arenda.BusinessLogic.Models;
using Arenda.WebAPI.Messages;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Arenda.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IApplicationService _applicationService;
        private readonly IOrderService _orderService;
        private readonly IConstructionService _constructionService;
        private readonly IMapper _mapper;
        private readonly IValidator<RegistrationRequest> _registrationValidator;
        private readonly IValidator<UpdateUserRequest> _updateUserValidator;

        public UserController(
            IUserService userService,
            IApplicationService applicationService,
            IOrderService orderService,
            IConstructionService constructionService,
            IMapper mapper,
            IValidator<RegistrationRequest> registrationValidator,
            IValidator<UpdateUserRequest> updateUserValidator)
        {
            _userService = userService;
            _applicationService = applicationService;
            _orderService = orderService;
            _constructionService = constructionService;
            _mapper = mapper;
            _registrationValidator = registrationValidator;
            _updateUserValidator = updateUserValidator;
        }

        [AllowAnonymous]
        [HttpPost(Name = nameof(Registration))]
        [SwaggerOperation(Summary = "Registration")]
        public async Task<ActionResult<RegistrationResponse>> Registration([FromBody] RegistrationRequest registrationRequest)
        {
            _registrationValidator.ValidateAndThrow(registrationRequest);

            var token = HttpContext.RequestAborted;
            var request = _mapper.Map<RegistrationRequest, CreateUser>(registrationRequest);
            var user = await _userService.CreateUser(request, token);
            var response = _mapper.Map<User, RegistrationResponse>(user);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("{userId}", Name = nameof(GetUser))]
        [SwaggerOperation(Summary = "GetUser")]
        public async Task<ActionResult<GetUserResponse>> GetUser([FromRoute] Guid userId)
        {
            var token = HttpContext.RequestAborted;
            var user = await _userService.GetUser(userId, token);
            var response = _mapper.Map<User, GetUserResponse>(user);

            return Ok(response);
        }

        [Authorize]
        [HttpGet(Name = nameof(GetCurrentUser))]
        [SwaggerOperation(Summary = "GetCurrentUser")]
        public async Task<ActionResult<GetUserResponse>> GetCurrentUser()
        {
            var token = HttpContext.RequestAborted;
            var user = await _userService.GetCurrentUser(token);
            var response = _mapper.Map<User, GetUserResponse>(user);

            return Ok(response);
        }

        [Authorize]
        [HttpPut("{userId}", Name = nameof(UpdateUser))]
        [SwaggerOperation(Summary = "UpdateUser")]
        public async Task<ActionResult<UpdateUserResponse>> UpdateUser([FromBody] UpdateUserRequest updateUser)
        {
            _updateUserValidator.ValidateAndThrow(updateUser);

            var token = HttpContext.RequestAborted;
            var request = _mapper.Map<UpdateUserRequest, UpdateUser>(updateUser);
            var user = await _userService.UpdateUser(request, token);
            var response = _mapper.Map<User, UpdateUserResponse>(user);

            return Ok(response);
        }

        [Authorize]
        [HttpPost("{userId}/application", Name = nameof(CreateApplication))]
        [SwaggerOperation(Summary = "CreateApplication")]
        public async Task<IActionResult> CreateApplication()
        {
            var token = HttpContext.RequestAborted;
            await _applicationService.CreateApplication(token);

            return Ok();
        }

        [Authorize]
        [HttpGet("{userId}/order", Name = nameof(GetUserOrders))]
        [SwaggerOperation(Summary = "GetUserOrders")]
        public async Task<ActionResult<GetUserOrdersResponse>> GetUserOrders([FromRoute] Guid userId)
        {
            var token = HttpContext.RequestAborted;
            var orders = await _orderService.GetAllOrders(userId, token);
            var response = _mapper.Map<List<BusinessLogic.Models.Order>, GetUserOrdersResponse>(orders);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("{userId}/construction", Name = nameof(GetUserConstructions))]
        [SwaggerOperation(Summary = "GetUserConstructions")]
        public async Task<ActionResult<GetUserOrdersResponse>> GetUserConstructions([FromRoute] Guid userId)
        {
            var token = HttpContext.RequestAborted;
            var constructions = await _constructionService.GetAllConstructionsByUserId(userId, token);
            var response = _mapper.Map<List<BusinessLogic.Models.Construction>, GetConstructionsResponse>(constructions);

            return Ok(response);
        }
    }
}
