using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation
{
    public class DapperExecutor : IDbExecutor
    {
        public async Task<int> ExecuteNonQuery(IDbConnection cn, string query, object param = null)
        {
            return await cn.ExecuteAsync(query, param);
        }

        public async Task<IEnumerable<T>> ExecuteReader<T>(IDbConnection cn, string query, object param = null)
        {
            return await cn.QueryAsync<T>(query, param);
        }

        public async Task<IEnumerable<T>> ExecuteReader<R, S, T>(IDbConnection cn, string query, Func<R, S, T> map, object param = null, string splitOn = "id")
        {
            return await cn.QueryAsync<R, S, T>(query, map, param, splitOn: splitOn);
        }
    }
}
