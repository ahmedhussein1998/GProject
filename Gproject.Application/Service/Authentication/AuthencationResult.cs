namespace GProject.Application.Service.Authentication;
public record AuthecationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);