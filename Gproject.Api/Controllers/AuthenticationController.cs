using ErrorOr;
using Gproject.contracts.Authentication;
using GProject.Application.Service.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{

    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthencationService _Service;
        public AuthenticationController(IAuthencationService service)
        {
            _Service = service;
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthecationResult> authResult = _Service.Register(request.FirstName, request.LastName, request.Email, request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
               errors => Problem(errors));
        }


        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _Service.Login(request.Email, request.Password);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );
           
        }

        private static AuthenticationResponse MapAuthResult(AuthecationResult authResult)
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
