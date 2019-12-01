using Dapper;
using DataAccess.Net.Interfaces;

namespace DataAccess.Net.Implementation.MySql
{
    public class MySqlClobParameterFactory : IClobParameterFactory
    {
        public SqlMapper.ICustomQueryParameter CreateParameter(string value)
        {
            return new MySqlClobParameter(value);
        }
    }
}
