using System;
using System.Data;
using Microsoft.Data.Sqlite;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation.Sqlite
{
    public class SqliteCtrlAccesDB : ICtrlAccesDB, IDisposable
    {
        private string _connectionString;
        private IDbConnection _connection;

        public SqliteCtrlAccesDB(string connectionString)
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
                _connection = new SqliteConnection
                {
                    ConnectionString = _connectionString
                };
                _connection.Open();
            }

            return _connection;
        }
    }
}
