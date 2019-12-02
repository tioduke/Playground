using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation.Oracle
{
    public class OracleAccesDB : ICtrlAccesDB, IDisposable
    {
        private string _connectionString;
        private IDbConnection _connection;

        public OracleAccesDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Dispose()
        {
            ReleaseConnection();
        }

        public void ReleaseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
            }
        }

        public IDbConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new OracleConnection
                {
                    ConnectionString = _connectionString
                };
                _connection.Open();
            }

            return _connection;
        }
    }
}
