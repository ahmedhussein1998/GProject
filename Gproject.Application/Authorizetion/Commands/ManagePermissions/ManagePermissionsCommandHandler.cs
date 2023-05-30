using ErrorOr;
using MediatR;
using Gproject.Domain.Common.Errors;
using Gproject.Domain.Common.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Gproject.Application.Authentication.Commands.ManagePermissions
{
    public class ManagePermissionsCommandHandler : IRequestHandler<ManagePermissionsCommand, ErrorOr<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManagePermissionsCommandHandler(
                                         IStringLocalizer<SharedResources> stringLocalizer,
                                        RoleManager<IdentityRole> roleManager)
        {
            _stringLocalizer = stringLocalizer;
            _roleManager = roleManager;
        }
        public async Task<ErrorOr<string>> Handle(ManagePermissionsCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var role = await _roleManager.FindByIdAsync(command.RoleId);

            if (role == null)
                return Errors.Role.RoleNotFound(_stringLocalizer);

            var roleClaims = await _roleManager.GetClaimsAsync(role);

            foreach (var claim in roleClaims)
                await _roleManager.RemoveClaimAsync(role, claim);

            var selectedClaims = command.RoleCalims.Where(c => c.IsSelected).ToList();

            foreach (var claim in selectedClaims)
                await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.DisplayValue));

            return _stringLocalizer[SharedResourcesKeys.CreateSuccess].ToString();


        }
    }
}
