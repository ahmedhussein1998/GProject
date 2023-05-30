using Gproject.Application.Authorizetion.Common;
using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.Entities;
using Gproject.Infrastruct.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Persistance.Repositories
{
    public class PermissionsRepositroy : IPermissionsRepositroy
    {


        public List<CheckBoxModel> GetAllPermissions()
        {
            var allClaims = Permissions.GenerateAllPermissions();
            return allClaims.Select(p => new CheckBoxModel { DisplayValue = p }).ToList();
        }


    }
}
