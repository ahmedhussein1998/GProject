using Gproject.Domain.UserAggregate;

namespace Gproject.Application.Authorizetion.Common
{
    public record ManagePermissionsResult(string RoleId, string RoleName, List<CheckBoxModel> RoleCalims);
    
}
