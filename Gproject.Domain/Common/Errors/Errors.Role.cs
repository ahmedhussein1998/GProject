using ErrorOr;
using Gproject.Domain.Common.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.Common.Errors
{
    public static partial class Errors 
    {
        public static class Role
        {
            public static Error RoleIsExists(IStringLocalizer<SharedResources> stringLocalizer)
            {
                string localizedString = stringLocalizer[SharedResourcesKeys.RoleIsExists];
                return Error.Conflict(code: "Role.RoleIsExists", description: localizedString);
            }

            public static Error RoleNotFound(IStringLocalizer<SharedResources> stringLocalizer)
            {
                string localizedString = stringLocalizer[SharedResourcesKeys.RoleNotFound];
                return Error.NotFound(code: "Role.RoleNotFound", description: localizedString);
            }



        }
    }
}
