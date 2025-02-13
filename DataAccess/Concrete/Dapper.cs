using TextForce.AssetManagement.Service.DataAccess.Abstract;
using Dapper;
using System.Data;
using System.Data.Common;
using TextForce.AssetManagement.Service.DataAccess.Infrastucture;

namespace TextForce.AssetManagement.Service.DataAccess.Concrete
{
    public class Dapper
    {
        public class DapperConcrete : IDapper
        {
            private readonly IConfiguration _config;
            private IConnectionFactory _Dbconnection = null;
            public DapperConcrete(IConfiguration config, IConnectionFactory conn)
            {
                _config = config;
                _Dbconnection = conn;
            }
            public void Dispose()
            {
            }
            public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
            {
                throw new NotImplementedException();
            }
            public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
            {
                using IDbConnection db = _Dbconnection.GetSQLConnection();
                return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            }
            public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
            {
                using IDbConnection db = _Dbconnection.GetSQLConnection();
                return db.Query<T>(sp, parms, commandType: commandType).ToList();
            }
            public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
            {
                T result;
                using IDbConnection db = _Dbconnection.GetSQLConnection();
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    using var tran = db.BeginTransaction();
                    try
                    {
                        result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }

                return result;
            }
            public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
            {
                T result;
                using IDbConnection db = _Dbconnection.GetSQLConnection();
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    using var tran = db.BeginTransaction();
                    try
                    {
                        result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }

                return result;
            }
        }
    }
}
