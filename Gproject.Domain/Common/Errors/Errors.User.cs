using ErrorOr;
using Gproject.Domain.Resources;
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
        public static IStringLocalizer<SharedResources> _stringLocalizer;
        static readonly Injection iii = new Injection();
        
        public static void method(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: SharedResourcesKeys.CreateSuccess.GetLocalization(LocalizedError._stringLocalizer) );
        }
    }
}
