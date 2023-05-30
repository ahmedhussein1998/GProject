using ErrorOr;
using MediatR;
using Gproject.Domain.Common.Errors;
using Gproject.Domain.Common.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Identity;

namespace Gproject.Application.Authentication.Commands.AddRole
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, ErrorOr<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRoleCommandHandler(
                                         IStringLocalizer<SharedResources> stringLocalizer,
                                        RoleManager<IdentityRole> roleManager)
        {
            _stringLocalizer = stringLocalizer;
            _roleManager = roleManager;
        }
        public async Task<ErrorOr<string>> Handle(AddRoleCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (await _roleManager.RoleExistsAsync(command.Name))
            {
                return Errors.Role.RoleIsExists(_stringLocalizer);
            }
            await _roleManager.CreateAsync(new IdentityRole(command.Name.Trim()));

            return _stringLocalizer[SharedResourcesKeys.CreateSuccess].ToString();


        }
    }
}
