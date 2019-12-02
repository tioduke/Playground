using System.IO;
using System.Data;
using System.Reflection;
using Microsoft.Data.Sqlite;
using Oracle.ManagedDataAccess.Client;

namespace DataAccess.Net.Tests
{
    public abstract class DbTester
    {
        protected void CreateInMemoryDB(IDbConnection connection)
        {
            var command = new SqliteCommand(GetSqlCommands("SqliteRepository.sql"), (SqliteConnection)connection);
            command.ExecuteNonQuery();
        }

        protected void PopulateOracleDB(IDbConnection connection)
        {
            var command = new OracleCommand(GetSqlCommands("OracleRepository.sql"), (OracleConnection)connection);
            command.ExecuteNonQuery();
        }

        private static string GetSqlCommands(string fileName)
        {
            var resourceName = "DataAccess.Net.Tests.Resources." + fileName;
            var assembly = Assembly.Load(new AssemblyName("DataAccess.Net.Tests"));

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null) throw new FileNotFoundException();

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
