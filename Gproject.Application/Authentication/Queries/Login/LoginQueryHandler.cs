using ErrorOr;
using Gproject.Application.Common.Interfaces.Authentication;
using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.Entities;
using MediatR;
using Gproject.Domain.Common.Errors;
using Gproject.Application.Authentication.Common;

namespace Gproject.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _JwtTokenGenerator;
        private readonly IUserRepositroy _userRepositroy;
        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepositroy userRepositroy)
        {
                _JwtTokenGenerator= jwtTokenGenerator;
                _userRepositroy= userRepositroy;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //1. Validata User Dose Exist
            if (_userRepositroy.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredential;
            }
            //2. Password Is Correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredential;
            }
            //3. Create JWT Token 
            var Token = _JwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
             user,
             Token
            );
        }
    }
}
