using System.Data;
using System.Data.SqlClient;

namespace TextForce.AssetManagement.Service.DataAccess.Infrastucture
{
    public interface IConnectionFactory
    {
        SqlConnection GetSQLConnection();
    }
}
