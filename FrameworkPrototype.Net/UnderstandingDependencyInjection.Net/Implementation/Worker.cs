using System;
using System.Threading.Tasks;

using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net.Implementation
{
    public class Worker : IWorker
    {
        private readonly ICustomerStrategy _customerStrategy;
        private readonly ICustomerStrategy _otherCustomerStrategy;

        public Worker(ICustomerStrategy customerStrategy, ICustomerStrategy otherCustomerStrategy)
        {
            _customerStrategy = customerStrategy;
            _otherCustomerStrategy = otherCustomerStrategy;
        }

        public async Task DoSomeWork()
        {
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
