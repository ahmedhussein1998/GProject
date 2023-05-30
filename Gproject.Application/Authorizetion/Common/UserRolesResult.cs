using Gproject.Domain.UserAggregate;

namespace Gproject.Application.Authorizetion.Common
{
    public record UserRolesResult(string Id,string UserName, IEnumerable<CheckBoxModel> Roles);
    
}
