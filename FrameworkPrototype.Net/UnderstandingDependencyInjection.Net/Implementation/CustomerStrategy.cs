using System.Collections.Generic;
using System.Threading.Tasks;

using DataAccess.Net.Interfaces;
using UnderstandingDependencyInjection.Net.Entities;
using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net.Implementation
{
    public class CustomerStrategy : ICustomerStrategy
    {
        private readonly IReadableRepository<Customer, CustomerCriteria> _customerRepository;

        public CustomerStrategy(ICtrlAccesDB accesBd, IReadableRepository<Customer, CustomerCriteria> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task­<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerRepository.FindMany(new CustomerCriteria { CustomerCode = "A" });
        }
    }
}
