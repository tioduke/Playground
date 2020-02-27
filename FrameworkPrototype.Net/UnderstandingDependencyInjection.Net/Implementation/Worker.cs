using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using DataAccess.Net.Interfaces;
using UnderstandingDependencyInjection.Net.Entities;
using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net.Implementation
{
    public class Worker : IWorker
    {
        private readonly Config _config;
        private readonly IReadableRepository<Customer> _otherCustomerRepository;
        private readonly IReadableRepository<Customer, CustomerCriteria> _customerRepository;

        public Worker(IOptions<Config> config,
                      ICtrlAccesDB accesBd,
                      IReadableRepository<Customer> otherCustomerRepository,
                      IReadableRepository<Customer, CustomerCriteria> customerRepository)
        {
            _config = config.Value;
            _customerRepository = customerRepository;
            _otherCustomerRepository = otherCustomerRepository;
        }

        public async Task DoSomeWork()
        {
            System.Console.WriteLine($"Username={_config.Username}, Passwrod={_config.Password}");

            var customers = await _customerRepository.FindMany(new CustomerCriteria { CustomerCode = "A" });

            foreach (var customer in customers)
            {
                System.Console.WriteLine(string.Format("Customer : Id={0}, Name={1}, Birth date={2}",
                                                       customer.Id, customer.CustomerName, customer.BirthDate));
            }
        }

        public async Task DoSomeOtherWork()
        {
            var customers = await _otherCustomerRepository.FindMany();

            foreach (var customer in customers)
            {
                System.Console.WriteLine(string.Format("Customer : Id={0}, Name={1}, Birth date={2}",
                                                       customer.Id, customer.CustomerName, customer.BirthDate));
            }
        }

    }
}
