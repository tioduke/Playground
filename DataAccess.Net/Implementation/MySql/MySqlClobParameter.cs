using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace DataAccess.Net.Implementation.MySql
{
    public class MySqlClobParameter : SqlMapper.ICustomQueryParameter
    {
        private readonly string _value;

        public MySqlClobParameter(string value)
        {
            _value = value;
        }

        public void AddParameter(IDbCommand command, string name)
        {
            var param = new MySqlParameter(name, MySqlDbType.LongText) { Value = _value };

            command.Parameters.Add(param);
        }
    }
}
