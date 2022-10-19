namespace GProject.Application.Services.Authentication;
public record AuthecationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);