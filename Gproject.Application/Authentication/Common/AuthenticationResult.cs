using Gproject.Domain.UserAggregate;

namespace Gproject.Application.Authentication.Common
{
    public record AuthenticationResult(ApplicationUser user, string Token);
    
}
