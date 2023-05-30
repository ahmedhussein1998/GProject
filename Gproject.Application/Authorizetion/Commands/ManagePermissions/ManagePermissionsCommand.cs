using ErrorOr;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Authorizetion.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Authentication.Commands.ManagePermissions
{
    public record ManagePermissionsCommand(
         string RoleId,
         string RoleName,
         List<CheckBoxModel> RoleCalims

         ) :IRequest<ErrorOr<string>>;


    

   
}
