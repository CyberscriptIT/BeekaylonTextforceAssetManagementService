using System.Data;
using System.Data.SqlClient;

namespace TextForce.AssetManagement.Service.DataAccess.Infrastructure
{
    public interface IConnectionFactory
    {
        SqlConnection GetSQLConnection();
    }
}
