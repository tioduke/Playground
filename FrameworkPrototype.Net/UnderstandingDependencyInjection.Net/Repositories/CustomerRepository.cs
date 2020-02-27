using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Net.Interfaces;
using DataAccess.Net.Implementation;
using UnderstandingDependencyInjection.Net.Entities;

namespace UnderstandingDependencyInjection.Net.Repositories
{
    public class CustomerRepository :
        BaseRepository<Customer>,
        IReadableRepository<Customer>,
        IReadableRepository<Customer, CustomerCriteria>
    {
        public CustomerRepository(ICtrlAccesDB accesDB, IDbExecutor dbExec)
            : base(accesDB, dbExec) { }

        public async Task<int> Count()
        {
            return await base.ExecuteCountRequest(CustomerSql.SqlCountAllCustomers, null);
        }

        public async Task<int> Count(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.CustomerCode == null)
                throw new ArgumentException(nameof(criteria));

            return await base.ExecuteCountRequest(CustomerSql.SqlCountCustomers, criteria);
        }

        public async Task<Customer> Find(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.Id == null)
                throw new ArgumentException(nameof(criteria));

            return (await base.ExecuteReaderRequest(CustomerSql.SqlSelectCustomer, criteria)).SingleOrDefault();
        }

        public async Task<IEnumerable<Customer>> FindMany()
        {
            return await base.ExecuteReaderRequest(CustomerSql.SqlSelectAllCustomers, null);
        }

        public async Task<IEnumerable<Customer>> FindMany(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.CustomerCode == null)
                throw new ArgumentException(nameof(criteria));

            return await base.ExecuteReaderRequest(CustomerSql.SqlSelectCustomers, criteria);
        }
    }
}