using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Net.Interfaces;
using DataAccess.Net.Implementation;
using DataAccess.Net.Tests.Entities;

namespace DataAccess.Net.Tests.Repositories
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
                throw new ArgumentException("criteria");

            return base.ExecuteReaderRequest<Address>(CustomerSql.SqlSelectCustomer,
                                                      (customer, address) =>
                                                      {
                                                        customer.Addresses = customer.Addresses ?? new List<Address>();
                                                        customer.Addresses.Add(address);
                                                        return customer;
                                                      }, criteria, "ADDRESS_ID").SingleOrDefault();
        }

        public IEnumerable<Customer> Find(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.CustomerCode == null)
                throw new ArgumentException("criteria");

            return base.ExecuteReaderRequest<Address>(CustomerSql.SqlSelectCustomers,
                                                      (customer, address) =>
                                                      {
                                                        customer.Addresses = customer.Addresses ?? new List<Address>();
                                                        customer.Addresses.Add(address);
                                                        return customer;
                                                      }, criteria, "ADDRESS_ID");
        }
    }
}