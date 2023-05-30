using ErrorOr;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Authorizetion.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Authentication.Commands.UpdateRoles
{
    public record UpdateRolesCommand(
         string UserId,
         string UserName,
         List<CheckBoxModel> Roles
         ) :IRequest<ErrorOr<string>>;


    

   
}
