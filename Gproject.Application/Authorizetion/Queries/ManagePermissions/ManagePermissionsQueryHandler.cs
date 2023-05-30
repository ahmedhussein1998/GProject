using ErrorOr;
using MediatR;
using Microsoft.Extensions.Localization;
using Gproject.Domain.Common.Resources;
using Microsoft.AspNetCore.Identity;
using Gproject.Domain.Common.Errors;
using Gproject.Application.Authorizetion.Common;
using Gproject.Application.Common.Interfaces.Persistance;

namespace Gproject.Application.Authorizetion.Queries.ManagePermissions
{
    public class ManagePermissionsQueryHandler : IRequestHandler<ManagePermissionsQuery, ErrorOr<ManagePermissionsResult>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPermissionsRepositroy _permissionsRepositroy;

        public ManagePermissionsQueryHandler( IStringLocalizer<SharedResources> stringLocalizer , RoleManager<IdentityRole> roleManager , IPermissionsRepositroy permissionsRepositroy)
        {
                _stringLocalizer= stringLocalizer;
                _roleManager = roleManager;
            _permissionsRepositroy = permissionsRepositroy;
        }
        public async Task<ErrorOr<ManagePermissionsResult>> Handle(ManagePermissionsQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var role = await _roleManager.FindByIdAsync(query.roleId);

            if (role == null)
                return Errors.Role.RoleNotFound(_stringLocalizer);

            var roleClaims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();

            var allPermissions = _permissionsRepositroy.GetAllPermissions();

            foreach (var permission in allPermissions)
            {
                if (roleClaims.Any(c => c == permission.DisplayValue))
                    permission.IsSelected = true;
            }


            var viewModel = new ManagePermissionsResult
            (  query.roleId,
                role.Name,
                allPermissions
            );


            return viewModel;


        }
    }
}
