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
        public static class Files
        {
            public static Error NotFound(IStringLocalizer<SharedResources> stringLocalizer)
            {
                string localizedString = stringLocalizer[SharedResourcesKeys.FileNotFound];
                return Error.NotFound(code: "FileNotFound", description: localizedString);
            }
        }
    }
}
