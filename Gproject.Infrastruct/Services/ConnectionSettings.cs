using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Services;

    public class ConnectionSettings
    {
        public const string SectionName = "ConnectionStrings";
        public string DefaultConnection { get; init; } = null!;
        
    }
