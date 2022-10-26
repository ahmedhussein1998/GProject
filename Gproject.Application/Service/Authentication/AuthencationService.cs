using ErrorOr;
using Gproject.Application.Common.Interfaces.Authentication;
using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.Common.Errors;
using Gproject.Domain.Entities;

namespace GProject.Application.Service.Authentication;

public class AuthencationService : IAuthencationService
{
    private readonly IJwtTokenGenerator _JwtTokenGenerator;
    private readonly IUserRepositroy _userRepositroy;

    public AuthencationService(IJwtTokenGenerator JwtTokenGenerator, IUserRepositroy UserRepositroy)
    {
        _JwtTokenGenerator = JwtTokenGenerator;
        _userRepositroy = UserRepositroy;
    }
    public ErrorOr<AuthecationResult> Register(string FirstName, string LastName, string Email, string Password)
    {
        //1. Check If User Already Exists
        if (_userRepositroy.GetUserByEmail(Email) != null)
        {
            return Errors.User.DuplicateEmail;
        }
        //2. Create User (Generate Unique ID) & Persist To DB
        var user = new User
        {
            FristName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password
        };
        _userRepositroy.AddUser(user);
        //3. Create Jwt Token
        Guid userId = Guid.NewGuid();
        var Token = _JwtTokenGenerator.GenerateToken(user);

        return new AuthecationResult(user, Token);
    }

    public ErrorOr<AuthecationResult> Login(string email, string Password)
    {
        //1. Validata User Dose Exist
        if (_userRepositroy.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }
        //2. Password Is Correct
        if (user.Password != Password)
        {
            return Errors.Authentication.InvalidCredential;
        }
        //3. Create JWT Token
        var Token = _JwtTokenGenerator.GenerateToken(user);

       return new AuthecationResult(
        user,
        Token
       );
    }
}