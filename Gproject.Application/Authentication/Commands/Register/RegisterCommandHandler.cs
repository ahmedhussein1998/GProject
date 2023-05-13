using ErrorOr;
using Gproject.Application.Common.Interfaces.Authentication;
using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.Entities;
using MediatR;
using Gproject.Domain.Common.Errors;
using Gproject.Application.Authentication.Common;
using Gproject.Domain.Common.Resources;
using Microsoft.Extensions.Localization;
using Gproject.Application.Common.Errors;

namespace Gproject.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _JwtTokenGenerator;
        private readonly IUserRepositroy _userRepositroy;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepositroy userRepositroy, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _JwtTokenGenerator = jwtTokenGenerator;
            _userRepositroy = userRepositroy;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //1. Check If User Already Exists
            if (_userRepositroy.GetUserByEmail(command.Email) != null)
            {
                return Errors.User.DuplicateEmail(_stringLocalizer);
            }
            //2. Create User (Generate Unique ID) & Persist To DB
            var user = new User
            {
                FristName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };
             _userRepositroy.AddUser(user);
            //3. Create Jwt Token
            var Token = _JwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, Token);
        }
    }
}
