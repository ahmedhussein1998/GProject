using Microsoft.AspNetCore.Authorization;

namespace Gproject.Api.Filters
{
        public class PermissionRequirement : IAuthorizationRequirement
        {
            public string Permission { get; private set; }

            public PermissionRequirement(string permission)
            {
                Permission = permission;
            }
        }
    }