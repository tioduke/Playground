using Dapper;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation.Oracle
{
    public class OracleClobParameterFactory : IClobParameterFactory
    {
        public SqlMapper.ICustomQueryParameter CreateParameter(string value)
        {
            return new OracleClobParameter(value);
        }
    }
}
