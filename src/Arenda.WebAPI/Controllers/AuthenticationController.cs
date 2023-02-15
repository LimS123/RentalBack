using Arenda.BusinessLogic.Contracts;
using Arenda.BusinessLogic.Models;
using Arenda.WebAPI.Messages;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Arenda.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IValidator<AuthenticateRequest> _authenticateValidator;
        private readonly IValidator<RefreshRequest> _refreshValidator;

        public AuthenticationController(
            IAuthService authService,
            IMapper mapper,
            IValidator<AuthenticateRequest> authenticateValidator,
            IValidator<RefreshRequest> refreshValidator)
        {
            _authService = authService;
            _mapper = mapper;
            _authenticateValidator = authenticateValidator;
            _refreshValidator = refreshValidator;
        }

        [AllowAnonymous]
        [HttpPost(Name = nameof(Authenticate))]
        [SwaggerOperation(Summary = "Authenticate")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] AuthenticateRequest authInfo)
        {
            _authenticateValidator.ValidateAndThrow(authInfo);

            var token = HttpContext.RequestAborted;
            var authenticate = await _authService.Authenticate(authInfo.Email!, authInfo.Password!, token);
            var response = _mapper.Map<Token, AuthenticateResponse>(authenticate);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh", Name = nameof(RefreshToken))]
        [SwaggerOperation(Summary = "RefreshToken")]
        public async Task<ActionResult<RefreshResponse>> RefreshToken([FromBody] RefreshRequest refresh)
        {
            _refreshValidator.ValidateAndThrow(refresh);

            var token = HttpContext.RequestAborted;
            var newToken = await _authService.Authenticate(refresh.RefreshToken!, token);
            var response = _mapper.Map<Token, RefreshResponse>(newToken);

            return Ok(response);
        }
    }
}
