using Gproject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Authentication.Common
{
    public record AuthenticationResult(User user, string Token);
    
}
