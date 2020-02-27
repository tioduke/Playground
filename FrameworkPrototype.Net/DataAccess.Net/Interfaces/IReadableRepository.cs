using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Net.Interfaces
{
    public interface IReadableRepository<TEntity>
    {
        Task<int> Count();
        Task<IEnumerable<TEntity>> FindMany();
    }

    public interface IReadableRepository<TEntity, TCriteria>
    {
        Task<int> Count(TCriteria criteres);
        Task<TEntity> Find(TCriteria criteres);
        Task<IEnumerable<TEntity>> FindMany(TCriteria criteres);
    }
}
