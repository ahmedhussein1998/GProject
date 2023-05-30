using ErrorOr;
using Gproject.Application.Common.Interfaces.Authentication;
using Gproject.Application.Common.Interfaces.Persistance;
using MediatR;
using Gproject.Domain.Common.Errors;
using Gproject.Application.Authentication.Common;
using Microsoft.Extensions.Localization;
using Gproject.Domain.Common.Resources;
using Microsoft.AspNetCore.Identity;
using Gproject.Domain.UserAggregate;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Gproject.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _JwtTokenGenerator;
        private readonly IUserRepositroy _userRepositroy;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepositroy userRepositroy, IStringLocalizer<SharedResources> stringLocalizer , UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
                _JwtTokenGenerator= jwtTokenGenerator;
                _userRepositroy= userRepositroy;
                _stringLocalizer= stringLocalizer;
                _userManager = userManager;
                _signInManager = signInManager;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //1. Validata User Dose Exist
            var user = await _userManager.FindByEmailAsync(query.Email);
            if (user == null)
            {
                return Errors.Authentication.InvalidCredential(_stringLocalizer);
            }
            //2. Password Is Correct

            var username = new EmailAddressAttribute().IsValid(query.Email) ? _userManager.FindByEmailAsync(query.Email).Result.UserName : query.Email;
            //var username = new EmailAddressAttribute().IsValid(query.Email) ? new MailAddress(query.Email).User : query.Email;

            var result = await _signInManager.PasswordSignInAsync(username, query.Password, query.RememberMe, false);
            if (result.Succeeded)
            {
                var Token = _JwtTokenGenerator.GenerateToken(user);
                return new AuthenticationResult(
                     user,
                     Token
                    );
            }
            else
            {
                return Errors.Authentication.InvalidCredential(_stringLocalizer);
            }

            //3. Create JWT Token 



        }
    }
}
