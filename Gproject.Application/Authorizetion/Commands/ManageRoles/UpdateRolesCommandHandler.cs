using ErrorOr;
using Gproject.Application.Common.Interfaces.Authentication;
using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.Entities;
using MediatR;
using Gproject.Domain.Common.Errors;
using Gproject.Application.Authentication.Common;
using Gproject.Domain.Common.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Identity;
using Gproject.Domain.UserAggregate;
using Gproject.Domain.Common.ValueObjects;
using System.Net.Mail;

namespace Gproject.Application.Authentication.Commands.UpdateRoles
{
    public class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, ErrorOr<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateRolesCommandHandler(
                                         IStringLocalizer<SharedResources> stringLocalizer,
                                         UserManager<ApplicationUser> userManager)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
        }
        public async Task<ErrorOr<string>> Handle(UpdateRolesCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var user = await _userManager.FindByIdAsync(command.UserId);

            if (user == null)
                return Errors.User.UserNotFound(_stringLocalizer);

            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, command.Roles.Where(r => r.IsSelected).Select(r => r.DisplayValue));
        
            return _stringLocalizer[SharedResourcesKeys.CreateSuccess].ToString();


        }
    }
}
