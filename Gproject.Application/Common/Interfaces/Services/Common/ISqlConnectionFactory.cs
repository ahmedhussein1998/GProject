
using Microsoft.Data.SqlClient;

namespace Gproject.Application.Common.Interfaces.Services.Common
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}