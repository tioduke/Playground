using System;
using System.Data;
using MySql.Data.MySqlClient;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation.Sqlite
{
    public class MySqlAccesDB : ICtrlAccesDB, IDisposable
    {
        private string _connectionString;
        private IDbConnection _connection;

        public MySqlAccesDB(string connectionString)
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
                _connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                _connection.Open();
            }

            return _connection;
        }
    }
}
