using Gproject.Domain.UserAggregate;

namespace Gproject.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }

 