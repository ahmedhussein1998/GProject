using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Common.Interfaces.Services.Common
{
    public record ResponseFileUploaded(string SavedName, bool IsPassed, string Message);
}
