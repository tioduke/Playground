using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Net.Interfaces;
using DataAccess.Net.Implementation;
using UnderstandingDependencyInjection.Net.Entities;

namespace UnderstandingDependencyInjection.Net.Repositories
{
    public class CustomerRepository :
        BaseRepository<Customer>,
        IReadableRepository<Customer, CustomerCriteria>
    {
        public CustomerRepository(ICtrlAccesDB accesDB, IDbExecutor dbExec)
            : base(accesDB, dbExec) { }

        public Customer FindById(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.Id == null)
                throw new ArgumentException(nameof(criteria));

            return base.ExecuteReaderRequest(CustomerSql.SqlSelectCustomer, criteria).SingleOrDefault();
        }

        public IEnumerable<Customer> Find(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.CustomerCode == null)
                throw new ArgumentException(nameof(criteria));

            return base.ExecuteReaderRequest(CustomerSql.SqlSelectCustomers, criteria);
        }

    }
}