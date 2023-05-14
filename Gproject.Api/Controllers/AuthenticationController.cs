using ErrorOr;
using Gproject.Application.Authentication.Commands.Register;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Authentication.Queries.Login;
using Gproject.contracts.Authentication;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{

    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        //private readonly IAuthencationCommandService _commandservice;
        //private readonly IAuthencationQueriesService _queriesService;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            //_commandservice = commandservice;
            //_queriesService = queriesService;
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand request)
       {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
               errors => Problem(errors));
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginQuery = _mapper.Map<LoginQuery>(request);
            var authResult =await _mediator.Send(loginQuery);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
           
        }

    }
}
