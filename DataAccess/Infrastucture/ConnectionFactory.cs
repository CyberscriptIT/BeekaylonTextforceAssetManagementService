using System.Data;
using System.Data.SqlClient;

namespace TextForce.AssetManagement.Service.DataAccess.Infrastucture
{
    public class ConnectionFactory : IConnectionFactory, IDisposable
    {

        private readonly string dbconnectionString = "";
        IConfiguration _config = null;
        SqlConnection conn = null;
        public ConnectionFactory(IConfiguration config)
        {
            _config = config;
            dbconnectionString = _config.GetSection("DbConnection").GetSection("server").Value;
        }

        public SqlConnection GetSQLConnection()
        {

            conn = new SqlConnection(dbconnectionString);
            conn.Open();
            return conn;

        }

        public void Dispose()
        {
        }
    }
}
