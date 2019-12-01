using System.Collections.Generic;

namespace DataAccess.Net.Interfaces
{
    public interface IReadableRepository<out TEntity>
    {
        int Count();
        IEnumerable<TEntity> FindMany();
    }

    public interface IReadableRepository<out TEntity, in TCriteria>
    {
        int Count(TCriteria criteres);
        TEntity Find(TCriteria criteres);
        IEnumerable<TEntity> FindMany(TCriteria criteres);
    }
}
