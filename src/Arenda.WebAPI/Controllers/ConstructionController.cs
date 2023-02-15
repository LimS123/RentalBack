using Arenda.BusinessLogic.Contracts;
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
    [Route("api/construction")]
    [ApiController]
    public class ConstructionController : ControllerBase
    {
        private readonly IConstructionService _constructionService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateConstructionRequest> _createConstructionValidator;
        private readonly IValidator<UpdateConstructionRequest> _updateConstructionValidator;
        private readonly IValidator<GetFilterConstructionsRequest> _filterConstructionsValidator;

        public ConstructionController(
            IConstructionService constructionService,
            IOrderService orderService,
            IMapper mapper,
            IValidator<CreateConstructionRequest> createConstructionValidator,
            IValidator<UpdateConstructionRequest> updateConstructionValidator,
            IValidator<GetFilterConstructionsRequest> filterConstructionsValidator)
        {
            _constructionService = constructionService;
            _orderService = orderService;
            _mapper = mapper;
            _createConstructionValidator = createConstructionValidator;
            _updateConstructionValidator = updateConstructionValidator;
            _filterConstructionsValidator = filterConstructionsValidator;
        }

        [Authorize(Roles = RoleTypes.Landlord)]
        [HttpPost(Name = nameof(CreateConstruction))]
        [SwaggerOperation(Summary = "CreateConstruction")]
        public async Task<ActionResult<CreateConstructionResponse>> CreateConstruction([FromForm] CreateConstructionRequest createConstruction)
        {
            _createConstructionValidator.ValidateAndThrow(createConstruction);

            var token = HttpContext.RequestAborted;
            var request = _mapper.Map<CreateConstructionRequest, CreateConstruction>(createConstruction);
            var construction = await _constructionService.CreateConstruction(request, token);
            var response = _mapper.Map<BusinessLogic.Models.Construction, CreateConstructionResponse>(construction);

            return Ok(response);
        }

        [Authorize(Roles = RoleTypes.Landlord)]
        [HttpPut("{constructionId}", Name = nameof(UpdateConstruction))]
        [SwaggerOperation(Summary = "UpdateConstruction")]
        public async Task<ActionResult<UpdateConstructionResponse>> UpdateConstruction([FromForm] UpdateConstructionRequest updateConstruction)
        {
            _updateConstructionValidator.ValidateAndThrow(updateConstruction);

            var token = HttpContext.RequestAborted;
            var request = _mapper.Map<UpdateConstructionRequest, UpdateConstruction>(updateConstruction);
            var construction = await _constructionService.UpdateConstruciton(request, token);
            var response = _mapper.Map<BusinessLogic.Models.Construction, UpdateConstructionResponse>(construction);

            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{constructionId}", Name = nameof(DeleteConstruction))]
        [SwaggerOperation(Summary = "DeleteConstruction")]
        public async Task<IActionResult> DeleteConstruction([FromRoute] Guid constructionId)
        {
            var token = HttpContext.RequestAborted;
            await _constructionService.RemoveConstruciton(constructionId, token);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{constructionId}", Name = nameof(GetConstruction))]
        [SwaggerOperation(Summary = "GetConstruction")]
        public async Task<ActionResult<GetConstructionResponse>> GetConstruction([FromRoute] Guid constructionId)
        {
            var token = HttpContext.RequestAborted;
            var construction = await _constructionService.GetConstruction(constructionId, token);
            var response = _mapper.Map<BusinessLogic.Models.Construction, GetConstructionResponse>(construction);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet(Name = nameof(GetConstructions))]
        [SwaggerOperation(Summary = "GetConstructions")]
        public async Task<ActionResult<GetConstructionsResponse>> GetConstructions([FromQuery] int page = 0, [FromQuery] int size = 10)
        {
            var token = HttpContext.RequestAborted;
            var constructions = await _constructionService.GetAllConstructions(page, size, token);
            var response = _mapper.Map<List<BusinessLogic.Models.Construction>, GetConstructionsResponse>(constructions);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPut("filter", Name = nameof(GetFilterConstructions))]
        [SwaggerOperation(Summary = "GetFilterConstructions")]
        public async Task<ActionResult<GetFilterConstructionsResponse>> GetFilterConstructions([FromBody] GetFilterConstructionsRequest filter,
            [FromQuery] int page = 0, [FromQuery] int size = 10)
        {
            _filterConstructionsValidator.Validate(filter);

            var token = HttpContext.RequestAborted;
            var constructionFilter = _mapper.Map<GetFilterConstructionsRequest, ConstructionFilter>(filter);
            var constructions = await _constructionService.GetAllConstructionsByFilter(constructionFilter, page, size, token);
            var response = _mapper.Map<List<BusinessLogic.Models.Construction>, GetFilterConstructionsResponse>(constructions);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("{constructionId}/order", Name = nameof(GetEndDate))]
        [SwaggerOperation(Summary = "GetEndDate")]
        public async Task<ActionResult<GetEndDateResponse>> GetEndDate([FromRoute] Guid constructionId)
        {
            var token = HttpContext.RequestAborted;
            var date = await _orderService.GetEndDateOfOrder(constructionId, token);
            var response = _mapper.Map<DateTime, GetEndDateResponse>(date);

            return response;
        }
    }
}
