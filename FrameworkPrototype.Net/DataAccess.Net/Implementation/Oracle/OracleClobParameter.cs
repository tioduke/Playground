using System.Data;
using System.Text;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace DataAccess.Net.Implementation.Oracle
{
    public class OracleClobParameter : SqlMapper.ICustomQueryParameter
    {
        private readonly string _value;

        public OracleClobParameter(string value)
        {
            _value = value;
        }

        public void AddParameter(IDbCommand command, string name)
        {
            // Accesing the connection in open state.
            var clob = new OracleClob(command.Connection as OracleConnection);

            // It should be Unicode oracle throws an exception when the length is not even.
            var bytes = Encoding.Unicode.GetBytes(_value);
            var length = Encoding.Unicode.GetByteCount(_value);

            int pos = 0;
            int chunkSize = 1024; // Oracle does not allow large chunks.

            while (pos < length)
            {
                chunkSize = chunkSize > (length - pos) ? length - pos : chunkSize;
                clob.Write(bytes, pos, chunkSize);
                pos += chunkSize;
            }

            var param = new OracleParameter(name, OracleDbType.Clob) { Value = clob };

            command.Parameters.Add(param);
        }
    }
}
