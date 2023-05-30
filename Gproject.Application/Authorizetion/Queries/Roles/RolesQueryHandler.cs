using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

using Gproject.Application.Authorizetion.Common;
using Microsoft.EntityFrameworkCore;

namespace Gproject.Application.Authorizetion.Queries.Roles
{
    public class RolesQueryHandler : IRequestHandler<RolesQuery, ErrorOr<List<IdentityRole>>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesQueryHandler(RoleManager<IdentityRole> roleManager)
        {
                _roleManager = roleManager;
        }
        public async Task<ErrorOr<List<IdentityRole>>> Handle(RolesQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;


        }
    }
}
