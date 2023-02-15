using Arenda.BusinessLogic.Contracts;
using Arenda.BusinessLogic.Contracts.Services;
using Arenda.BusinessLogic.Models;
using Arenda.BusinessLogic.Services;
using Arenda.WebAPI.Infrastructure.Constants;
using Arenda.WebAPI.Messages;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Arenda.WebAPI.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationController(
            IApplicationService applicationService,
            IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [Authorize(Roles = RoleTypes.Administrator)]
        [HttpPut("{applicationId}/approve", Name = nameof(ApproveApplication))]
        [SwaggerOperation(Summary = "ApproveApplication")]
        public async Task<ActionResult<ApproveApplicationResponse>> ApproveApplication([FromRoute] Guid applicationId)
        {
            var token = HttpContext.RequestAborted;

            var application = await _applicationService.ApproveApplication(applicationId, token);
            var response = _mapper.Map<BusinessLogic.Models.Application, ApproveApplicationResponse>(application);

            return Ok(response);
        }

        [Authorize(Roles = RoleTypes.Administrator)]
        [HttpGet(Name = nameof(GetApplications))]
        [SwaggerOperation(Summary = "GetApplications")]
        public async Task<ActionResult<GetApplicationsResponse>> GetApplications([FromQuery] int page = 0, [FromQuery] int size = 10)
        {
            var token = HttpContext.RequestAborted;
            var applications = await _applicationService.GetAllApplications(page, size, token);
            var response = _mapper.Map<List<BusinessLogic.Models.Application>, GetApplicationsResponse>(applications);

            return Ok(response);
        }
    }
}
