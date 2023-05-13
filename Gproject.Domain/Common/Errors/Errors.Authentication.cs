using ErrorOr;
using Gproject.Domain.Common.Resources;
using Microsoft.Extensions.Localization;


namespace Gproject.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredential(IStringLocalizer<SharedResources> stringLocalizer)
            {
                string localizedString = stringLocalizer[SharedResourcesKeys.InvalidCredintal];
                return Error.Validation(code: "Auth.InvalidCredintal", description: localizedString);
            } 

        }
    }
}
