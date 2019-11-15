using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Net.Interfaces;
using DataAccess.Net.Implementation;
using UnderstandingDependencyInjection.Net.Entities;

namespace UnderstandingDependencyInjection.Net.Repositories
{
    public class VoidCustomerRepository :
        BaseRepository<Customer>,
        IReadableRepository<Customer, Unused>
    {
        public VoidCustomerRepository(ICtrlAccesDB accesDB, IDbExecutor dbExec)
            : base(accesDB, dbExec) { }

        public int Count(Unused _)
        {
            return base.ExecuteCountRequest(VoidCustomerSql.SqlCountCustomers, null);
        }

        public Customer FindById(Unused _)
        {
            throw new InvalidOperationException("Method Find cannot be called in this context.");
        }

        public IEnumerable<Customer> Find(Unused _)
        {
            return base.ExecuteReaderRequest(VoidCustomerSql.SqlSelectCustomers, null);
        }
    }
}