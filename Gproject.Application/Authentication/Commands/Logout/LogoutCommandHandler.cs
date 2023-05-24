using ErrorOr;
using Gproject.Application.Common.Interfaces.Persistance;
using MediatR;
using Gproject.Application.Authentication.Common;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Identity;
using Gproject.Domain.UserAggregate;
using Gproject.Application.Resources;

namespace Gproject.Application.Authentication.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, ErrorOr<string>>
    {
      
        private readonly IUserRepositroy _userRepositroy;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutCommandHandler( IUserRepositroy userRepositroy, IStringLocalizer<SharedResources> stringLocalizer, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
           
            _userRepositroy = userRepositroy;
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ErrorOr<string>> Handle(LogoutCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
             await _signInManager.SignOutAsync();

         
         return _stringLocalizer[SharedResourcesKeys.Logout].ToString();



        }
    }
}
