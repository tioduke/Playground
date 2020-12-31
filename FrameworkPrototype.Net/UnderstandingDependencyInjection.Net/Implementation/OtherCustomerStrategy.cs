using System.Collections.Generic;
using System.Threading.Tasks;

using DataAccess.Net.Interfaces;
using UnderstandingDependencyInjection.Net.Entities;
using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net.Implementation
{
    public class OtherCustomerStrategy : ICustomerStrategy
    {
        private readonly IReadableRepository<Customer> _otherCustomerRepository;

        public OtherCustomerStrategy(ICtrlAccesDB accesBd, IReadableRepository<Customer> otherCustomerRepository)
        {
            _otherCustomerRepository = otherCustomerRepository;
        }

        public async Task­<IEnumerable<Customer>> GetCustomers()
        {
            return await _otherCustomerRepository.FindMany();
        }
    }
}
