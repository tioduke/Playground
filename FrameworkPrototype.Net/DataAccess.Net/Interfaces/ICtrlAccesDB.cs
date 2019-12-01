using System.Data;

namespace DataAccess.Net.Interfaces
{
    public interface ICtrlAccesDB
    {
        IDbConnection GetConnection();
        void ReleaseConnection();
    }
}
