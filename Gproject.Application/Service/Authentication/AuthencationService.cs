namespace GProject.Application.Service.Authentication;

public class AuthencationService : IAuthencationService
{
    public AuthecationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        return new AuthecationResult(Guid.NewGuid(),FirstName,LastName,Email,"Token");
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