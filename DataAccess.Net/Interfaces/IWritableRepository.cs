namespace DataAccess.Net.Interfaces
{
    public interface IWritableRepository<in TEntity, in TCriteria>
    {
        long GetSequence();
        int Insert(TEntity entite);
        int Update(TEntity entite, TCriteria criteres=default(TCriteria));
        int Delete(TCriteria criteres);
    }
}
