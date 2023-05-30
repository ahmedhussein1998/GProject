using Gproject.Domain.UserAggregate;

namespace Gproject.Application.Authorizetion.Common
{
    public record UserResult(string Id,string UserName,string Email, IEnumerable<string> Roles);
    
}
