using Gproject.Application.Common.Interfaces.Authentication;

namespace GProject.Application.Service.Authentication;

public class AuthencationService : IAuthencationService
{
    private readonly IJwtTokenGenerator _JwtTokenGenerator;

    public AuthencationService(IJwtTokenGenerator JwtTokenGenerator)
    {
        _JwtTokenGenerator = JwtTokenGenerator;
    }
    public AuthecationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        //Check If User Already Exists

        //Create User (Generate Unique ID)

        // Create Jwt Token
        Guid userId = Guid.NewGuid();
        var Token = _JwtTokenGenerator.GenerateToken(userId, FirstName, LastName);


        return new AuthecationResult(userId, FirstName, LastName, Email, Token);
    }

    public AuthecationResult Login(string FirstName, string Password)
    {
       return new AuthecationResult(
        Guid.NewGuid(),
        "firstName",
        "LastName",
        Password,
        "email"
       );
    }
}