using Gproject.Domain.Entities;

namespace GProject.Application.Service.Authentication;
public record AuthecationResult(
    User user,
    string Token
);