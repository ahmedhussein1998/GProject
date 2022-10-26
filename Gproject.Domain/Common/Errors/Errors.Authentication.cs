using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        { 
            public static Error InvalidCredential => Error.Validation(code: "Auth.InvalidCredintal", description: "Invalid Credentials.");
        }
    }
}
