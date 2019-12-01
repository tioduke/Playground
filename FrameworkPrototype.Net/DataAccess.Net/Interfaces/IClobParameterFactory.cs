using Dapper;

namespace DataAccess.Net.Interfaces
{
    public interface IClobParameterFactory
    {
        SqlMapper.ICustomQueryParameter CreateParameter(string value);
    }
}
