using System.Collections.Generic;
using System.Data;

namespace DataAccess.Net.Interfaces
{
    public interface IDbExecutor
    {
        int ExecuteNonQuery(IDbConnection cn, string query, object param = null);
        IEnumerable<T> ExecuteReader<T>(IDbConnection cn, string query, object param = null);
    }
}
