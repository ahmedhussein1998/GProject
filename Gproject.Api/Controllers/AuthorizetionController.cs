using ErrorOr;
using Gproject.Application.Authentication.Commands.Logout;
using Gproject.Application.Authentication.Commands.Register;
using Gproject.Application.Authentication.Commands.UpdateRoles;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Authentication.Queries.Login;
using Gproject.Application.Authorizetion.Queries.User;
using Gproject.contracts.Authentication;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{

    [Route("Authorizetion")]
    [AllowAnonymous]
    [Authorize(Roles = "SuperAdmin")]

    public class AuthorizetionController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthorizetionController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("ListUsersRoles")]
        public async Task<IActionResult> ListUsersRoles()
        {
            UsersQuery query = new UsersQuery();
            var users = await _mediator.Send(query);

            return users.Match(
                Result => Ok(users),
                errors => Problem(errors)
                );
        }

        [HttpGet("ManageRoles")]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            ManageRolesQuery query = new ManageRolesQuery(userId);
            var userRoles = await _mediator.Send(query);

            return userRoles.Match(
                Result => Ok(userRoles),
                errors => Problem(errors)
                );

        }

        [HttpPost("UpdateRoles")]
        public async Task<IActionResult> UpdateRoles(UpdateRolesCommand command)
        {
            ErrorOr<string> authResult = await _mediator.Send(command);

            return authResult.Match(
                Result => Ok(authResult),
               errors => Problem(errors));
        }



    }
}
