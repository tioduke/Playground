using System.Threading.Tasks;

namespace DataAccess.Net.Interfaces
{
    public interface IWritableRepository<in TEntity, in TCriteria>
    {
        Task<long> GetSequence();
        Task<int> Insert(TEntity entite);
        Task<int> Update(TEntity entite, TCriteria criteres=default(TCriteria));
        Task<int> Delete(TCriteria criteres);
    }
}
