using Gproject.Application.Common.Interfaces.Services.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Services
{
    internal class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly ConnectionSettings _connectionSettings;

        public SqlConnectionFactory(IOptions<ConnectionSettings> connectionSettings)
        {
            _connectionSettings = connectionSettings.Value;
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(
                _connectionSettings.DefaultConnection);
        }
    }
}
