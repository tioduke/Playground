using System;
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

        public IEnumerable<T> ExecuteReader<R, S, T>(IDbConnection cn, string query, Func<R, S, T> map, object param = null, string splitOn = "id")
        {
            return cn.Query<R, S, T>(query, map, param, splitOn: splitOn);
        }
    }
}
