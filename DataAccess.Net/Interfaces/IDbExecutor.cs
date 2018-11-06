using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.Net.Interfaces
{
    public interface IDbExecutor
    {
        int ExecuteNonQuery(IDbConnection cn, string query, object param = null);
        IEnumerable<T> ExecuteReader<T>(IDbConnection cn, string query, object param = null);
        IEnumerable<T> ExecuteReader<T, S>(IDbConnection cn, string query, Func<T, S, T> map, object param = null, string splitOn = "id");
    }
}
