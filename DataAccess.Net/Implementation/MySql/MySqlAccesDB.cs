using System;
using System.Data;
using MySql.Data.MySqlClient;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation.Sqlite
{
    public class MySqlCtrlAccesDB : ICtrlAccesDB, IDisposable
    {
        private string _connectionId;
        private IDbConnection _connection;

        public MySqlCtrlAccesDB(string connectionId)
        {
            this._connectionId = connectionId;
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
                this._connection = new MySqlConnection
                {
                    ConnectionString = this._connectionId
                };
                this._connection.Open();
            }

            return this._connection;
        }
    }
}
