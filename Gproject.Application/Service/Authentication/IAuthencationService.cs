using ErrorOr;

namespace GProject.Application.Service.Authentication;

public interface IAuthencationService
{
    ErrorOr<AuthecationResult> Login(string FirstName, string Password);
    ErrorOr<AuthecationResult> Register(string FirstName, string LastName, string Email, string Password);
}