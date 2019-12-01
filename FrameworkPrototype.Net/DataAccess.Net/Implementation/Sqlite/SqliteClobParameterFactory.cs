using Dapper;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation.Sqlite
{
    public class SqliteClobParameterFactory : IClobParameterFactory
    {
        public SqlMapper.ICustomQueryParameter CreateParameter(string value)
        {
            return new DbString { Value = value };
        }
    }
}
