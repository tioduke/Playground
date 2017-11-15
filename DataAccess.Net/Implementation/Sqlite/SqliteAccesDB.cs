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
            this._connectionString = connectionString;
        }

        public void Dispose()
        {
            this.ReleaseConnection();
        }

        public void ReleaseConnection()
        {
            if (this._connection != null)
            {
                this._connection.Close();
                this._connection = null;
            }
        }

        public IDbConnection GetConnection()
        {
            if (this._connection == null)
            {
                this._connection = new SqliteConnection
                {
                    ConnectionString = this._connectionString
                };
                this._connection.Open();
            }

            return this._connection;
        }
    }
}
