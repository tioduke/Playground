using System;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using Microsoft.Extensions.Options;

using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net.Implementation
{
    public class Worker : IWorker
    {
        private readonly Config _config;
        private readonly ICustomerStrategy _customerStrategy;
        private readonly ICustomerStrategy _otherCustomerStrategy;

        public Worker(IOptions<Config> config,
            [MetadataFilter("CustomerStrategy", "filtered")] ICustomerStrategy customerStrategy,
            [MetadataFilter("CustomerStrategy", "allOfThem")] ICustomerStrategy otherCustomerStrategy)
        {
            _config = config.Value;
            _customerStrategy = customerStrategy;
            _otherCustomerStrategy = otherCustomerStrategy;

            Console.WriteLine($"CustomerStrategy : {_customerStrategy.GetType()}");
            Console.WriteLine($"OtherCustomerStrategy : {_otherCustomerStrategy.GetType()}");
        }

        public async Task DoSomeWork()
        {
            Console.WriteLine($"Username={_config.Username}, Passwrod={_config.Password}");

            var customers = await _customerStrategy.GetCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine(string.Format("Customer : Id={0}, Name={1}, Birth date={2}",
                    customer.Id, customer.CustomerName, customer.BirthDate));
            }
        }

        public async Task DoSomeOtherWork()
        {
            var customers = await _otherCustomerStrategy.GetCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine(string.Format("Customer : Id={0}, Name={1}, Birth date={2}",
                    customer.Id, customer.CustomerName, customer.BirthDate));
            }
        }
    }
}
