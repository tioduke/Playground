using System.Collections.Generic;

namespace DataAccess.Net.Interfaces
{
    public interface IReadableRepository<out TEntity, in TCriteria>
    {
        int Count(TCriteria criteres);
        TEntity FindById(TCriteria criteres);
        IEnumerable<TEntity> Find(TCriteria criteres);
    }
}
