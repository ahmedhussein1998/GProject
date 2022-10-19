using Gproject.contracts.Authentication;
using GProject.Application.Service.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthencationService _Service;
        public AuthenticationController(IAuthencationService service)
        {
            _Service = service;
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _Service.Register(request.FirstName, request.LastName, request.Email, request.Password);
            var response = new AuthenticationResponse(
               authResult.Id,
               authResult.FirstName,
               authResult.Email,
               authResult.Email,
               authResult.Token
            );
            return Ok(response);
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _Service.Login(request.Email, request.Password);
            var response = new AuthenticationResponse(
               authResult.Id,
               authResult.FirstName,
               authResult.Email,
               authResult.Email,
               authResult.Token
            );
            return Ok(response);
        }


    }
}
