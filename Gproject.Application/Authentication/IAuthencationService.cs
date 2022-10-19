namespace GProject.Application.Services.Authentication;

public interface IAuthencationService
{
    AuthecationResult Login(string FirstName, string Password);
    AuthecationResult Register(string FirstName, string LastName, string Email, string Password);
}