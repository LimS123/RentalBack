using Arenda.BusinessLogic.Contracts.Services;
using Arenda.BusinessLogic.Models;
using Arenda.WebAPI.Infrastructure.Constants;
using Arenda.WebAPI.Messages;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Arenda.WebAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOrderRequest> _createOrderValidator;

        public OrderController(
            IOrderService orderService,
            IMapper mapper,
            IValidator<CreateOrderRequest> createOrderValidator)
        {
            _orderService = orderService;
            _mapper = mapper;
            _createOrderValidator = createOrderValidator;
        }

        [Authorize]
        [HttpPost(Name = nameof(CreateOrder))]
        [SwaggerOperation(Summary = "CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest createOrder)
        {
            //_createOrderValidator.ValidateAndThrow(createOrder);

            var token = HttpContext.RequestAborted;
            var request = _mapper.Map<CreateOrderRequest, CreateOrder>(createOrder);
            await _orderService.CreateOrder(request, token);

            return Ok();
        }
    }
}
