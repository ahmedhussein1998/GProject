using Gproject.Domain.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.Common.Errors
{
    public static class LocalizedError
    {
        public static IStringLocalizer<SharedResources> _stringLocalizer;
        public static string GetLocalization(this string input, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            return _stringLocalizer[input].ToString();
        }

    }
}
