using System.Data;
using Microsoft.Data.Sqlite;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation.Sqlite
{
    public class SqliteCtrlAccesDB : ICtrlAccesDB
    {
        private string _connectionId;
        private IDbConnection _connection;

        public SqliteCtrlAccesDB(string connectionId)
        {
            this._connectionId = connectionId;
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
                    ConnectionString = this._connectionId
                };
                this._connection.Open();
            }

            return this._connection;
        }
    }
}
