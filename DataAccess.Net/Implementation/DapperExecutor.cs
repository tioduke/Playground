using System.Collections.Generic;
using System.Data;
using Dapper;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation
{
    public class DapperExecutor : IDbExecutor
    {
        public int ExecuteNonQuery(IDbConnection cn, string query, object param = null)
        {
            return cn.Execute(query, param);
        }

        public IEnumerable<T> ExecuteReader<T>(IDbConnection cn, string query, object param = null)
        {
            return cn.Query<T>(query, param);
        }
    }
}
