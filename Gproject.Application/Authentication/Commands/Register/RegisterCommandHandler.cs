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

namespace Gproject.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _JwtTokenGenerator;
        private readonly IUserRepositroy _userRepositroy;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepositroy userRepositroy, IStringLocalizer<SharedResources> stringLocalizer, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _JwtTokenGenerator = jwtTokenGenerator;
            _userRepositroy = userRepositroy;
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var user = await _userManager.FindByEmailAsync(command.Email);

            //1. Check If User Already Exists
            if (user != null)
            {
                return Errors.User.DuplicateEmail(_stringLocalizer);
            }
            //2. Create User (Generate Unique ID) & Persist To DB
            var applicationUser = new ApplicationUser
            {
                FullName = new FullName(command.FirstName, command.SecondName, command.ThirdName, command.LastName),
                Email = command.Email,
                UserName = new MailAddress(command.Email).User,
                Gender = new KeyValueLocalized(command.GenderCode, command.GenderDescriptionAr, command.GenderDescriptionEn),
                Nationality = new KeyValueLocalized(command.NationalityCode, command.NationalityDescriptionAr, command.NationalityDescriptionEn),
                Phone =new CellPhone(command.CountryPrefix,command.Number),
                PictureFileName = command.PictureFileName
            };
            var result = await _userManager.CreateAsync(applicationUser, command.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);

                //3. Create Jwt Token
                var Token = _JwtTokenGenerator.GenerateToken(applicationUser);

                return new AuthenticationResult(applicationUser, Token);
            }
            else
            {
                    var errors = result.Errors.Select(Failure =>
                            Error.Failure(Failure.Code, Failure.Description)).ToList();
                    return (dynamic)errors;
              
            }

        }
    }
}
