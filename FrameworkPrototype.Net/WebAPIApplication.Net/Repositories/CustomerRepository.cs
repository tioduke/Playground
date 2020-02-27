using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Net.Interfaces;
using DataAccess.Net.Implementation;
using WebAPIApplication.Net.Entities;

namespace WebAPIApplication.Net.Repositories
{
    public class CustomerRepository :
        BaseRepository<Customer>,
        IReadableRepository<Customer, CustomerCriteria>,
        IWritableRepository<Customer, CustomerCriteria>
    {
        public CustomerRepository(ICtrlAccesDB accesDB, IDbExecutor dbExec)
            : base(accesDB, dbExec) { }

        public async Task<int> Count(CustomerCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentException(nameof(criteria));

            return await base.ExecuteCountRequest(CustomerSql.SqlCountCustomers(criteria), criteria);
        }

        public async Task<Customer> Find(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.Id == null)
                throw new ArgumentException(nameof(criteria));

            return (await base.ExecuteReaderRequest(CustomerSql.SqlSelectCustomer, criteria)).SingleOrDefault();
        }

        public async Task<IEnumerable<Customer>> FindMany(CustomerCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentException(nameof(criteria));

            return await base.ExecuteReaderRequest(CustomerSql.SqlSelectCustomers(criteria), criteria);
        }

        public Task<long> GetSequence()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(Customer entity)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity));

            return await base.ExecuteNonQueryRequest(CustomerSql.SqlInsert, entity);
        }

        public async Task<int> Update(Customer entity, CustomerCriteria criteria)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity));

            return await base.ExecuteNonQueryRequest(CustomerSql.SqlUpdate, entity);
        }

        public async Task<int> Delete(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.Id == null)
                throw new ArgumentException(nameof(criteria));

            return await base.ExecuteNonQueryRequest(CustomerSql.SqlDelete, criteria);
        }
    }
}