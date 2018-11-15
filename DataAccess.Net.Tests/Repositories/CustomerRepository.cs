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
                throw new ArgumentException(nameof(criteria));

            this._mappingDictionary = new Dictionary<long, Customer>();
            return base.ExecuteReaderRequest<Customer, Address>(CustomerSql.SqlSelectCustomer, criteria, this.MappingFunction, "ADDRESS_ID").SingleOrDefault();
        }

        public IEnumerable<Customer> Find(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.CustomerCode == null)
                throw new ArgumentException(nameof(criteria));

            this._mappingDictionary = new Dictionary<long, Customer>();
            return base.ExecuteReaderRequest<Customer, Address>(CustomerSql.SqlSelectCustomers, criteria, this.MappingFunction, "ADDRESS_ID");
        }

        #region Customer, Address mapping

        private IDictionary<long, Customer> _mappingDictionary;

        private Customer MappingFunction(Customer customer, Address address)
        {
            Customer customerEntry;

            if (!this._mappingDictionary.TryGetValue(customer.Id, out customerEntry))
            {
                customerEntry = customer;
                customerEntry.Addresses = new List<Address>();
                this._mappingDictionary.Add(customerEntry.Id, customerEntry);
            }

            customerEntry.Addresses.Add(address);
            return customerEntry;
        }

        #endregion
    }
}