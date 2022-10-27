using ErrorOr;
using Gproject.Application.Authentication.Commands.Register;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Authentication.Queries.Login;
using Gproject.contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{

    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        //private readonly IAuthencationCommandService _commandservice;
        //private readonly IAuthencationQueriesService _queriesService;
        private readonly ISender _mediator;

        public AuthenticationController(IMediator mediator)
        {
            //_commandservice = commandservice;
            //_queriesService = queriesService;
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
               errors => Problem(errors));
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var loginQuery = new LoginQuery(request.Email, request.Password);
            var authResult =await _mediator.Send(loginQuery);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );
           
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
               authResult.user.Id,
               authResult.user.FristName,
               authResult.user.LastName,
               authResult.user.Email,
               authResult.Token
            );
        }


    }
}
