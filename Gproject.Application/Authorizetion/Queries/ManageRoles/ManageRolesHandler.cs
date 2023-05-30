using ErrorOr;
using Gproject.Application.Common.Interfaces.Persistance;
using MediatR;
using Microsoft.Extensions.Localization;
using Gproject.Domain.Common.Resources;
using Microsoft.AspNetCore.Identity;
using Gproject.Domain.UserAggregate;
using Gproject.Domain.Common.Errors;


using Gproject.Application.Authorizetion.Common;
using Microsoft.EntityFrameworkCore;

namespace Gproject.Application.Authorizetion.Queries.User
{
    public class ManageRolesQueryHandler : IRequestHandler<ManageRolesQuery, ErrorOr<UserRolesResult>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageRolesQueryHandler( IStringLocalizer<SharedResources> stringLocalizer , UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
                _stringLocalizer= stringLocalizer;
                _userManager = userManager;
                _roleManager = roleManager;
        }
        public async Task<ErrorOr<UserRolesResult>> Handle(ManageRolesQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var user = await _userManager.FindByIdAsync(query.userId);

            if (user == null)
                return Errors.User.UserNotFound(_stringLocalizer);

            var roles = await _roleManager.Roles.ToListAsync();

            var UserRoles = new UserRolesResult
            (
                user.Id,
                user.UserName,
                roles.Select(role => new CheckBoxModel
                {
                    DisplayValue = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            );


            return UserRoles;


        }
    }
}
