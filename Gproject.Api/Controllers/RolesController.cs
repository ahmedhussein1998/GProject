using ErrorOr;
using Gproject.Application.Authentication.Commands.AddRole;
using Gproject.Application.Authentication.Commands.Logout;
using Gproject.Application.Authentication.Commands.ManagePermissions;
using Gproject.Application.Authentication.Commands.Register;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Authentication.Queries.Login;
using Gproject.Application.Authorizetion.Queries.ManagePermissions;
using Gproject.Application.Authorizetion.Queries.Roles;
using Gproject.contracts.Authentication;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{

    [Route("Roles")]
    [Authorize(Roles = "SuperAdmin")]
    public class RolesController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public RolesController(IMediator mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("ListAllRoles")]
        public async Task<IActionResult> ListAllRoles()
        {
            RolesQuery query = new RolesQuery();
            var roles = await _mediator.Send(query);

            
            return roles.Match(
                authResult => Ok(roles),
                errors => Problem(errors!.ToString())
                );
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddRoleCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
                );

        }

        [HttpGet("ManagePermissions/roleId")]
        public async Task<IActionResult> ManagePermissions(string roleId)
        {
            ManagePermissionsQuery query = new ManagePermissionsQuery(roleId);

            var result = await _mediator.Send(query);

            return result.Match(
               result => Ok(result),
               errors => Problem(errors));
        }


        [HttpPost("ManagePermissions")]
        public async Task<IActionResult> ManagePermissions(ManagePermissionsCommand command)
        {

            var result = await _mediator.Send(command);

            return result.Match(
               result => Ok(result),
               errors => Problem(errors));
        }



    }
}
