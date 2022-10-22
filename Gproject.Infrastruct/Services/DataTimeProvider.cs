using Gproject.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Services;
    public class DataTimeProvider : IDataTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }

