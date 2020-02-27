using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            _mappingDictionary = new Dictionary<long, Customer>();
            return (await base.ExecuteReaderRequest<Customer, Address>(CustomerSql.SqlSelectCustomer, criteria, MappingFunction, "ADDRESS_ID")).SingleOrDefault();
        }

        public async Task<IEnumerable<Customer>> FindMany(CustomerCriteria criteria)
        {
            if (criteria == null || criteria.CustomerCode == null)
                throw new ArgumentException(nameof(criteria));

            _mappingDictionary = new Dictionary<long, Customer>();
            return await base.ExecuteReaderRequest<Customer, Address>(CustomerSql.SqlSelectCustomers, criteria, MappingFunction, "ADDRESS_ID");
        }

        #region Customer, Address mapping

        private IDictionary<long, Customer> _mappingDictionary;

        private Customer MappingFunction(Customer customer, Address address)
        {
            Customer customerEntry;

            if (!_mappingDictionary.TryGetValue(customer.Id, out customerEntry))
            {
                customerEntry = customer;
                customerEntry.Addresses = new List<Address>();
                _mappingDictionary.Add(customerEntry.Id, customerEntry);
            }

            customerEntry.Addresses.Add(address);
            return customerEntry;
        }

        #endregion
    }
}