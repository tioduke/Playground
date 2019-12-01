using DataAccess.Net.Interfaces;
using UnderstandingDependencyInjection.Net.Entities;
using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net.Implementation
{
    public class Worker : IWorker
    {
        private readonly IReadableRepository<Customer> _otherCustomerRepository;
        private readonly IReadableRepository<Customer, CustomerCriteria> _customerRepository;

        public Worker(ICtrlAccesDB accesBd,
                      IReadableRepository<Customer> otherCustomerRepository,
                      IReadableRepository<Customer, CustomerCriteria> customerRepository)
        {
            _customerRepository = customerRepository;
            _otherCustomerRepository = otherCustomerRepository;
        }

        public void DoSomeWork()
        {
            var customers = _customerRepository.FindMany(new CustomerCriteria { CustomerCode = "A" });

            foreach (var customer in customers)
            {
                System.Console.WriteLine(string.Format("Customer : Id={0}, Name={1}, Birth date={2}",
                                                       customer.Id, customer.CustomerName, customer.BirthDate));
            }
        }

        public void DoSomeOtherWork()
        {
            var customers = _otherCustomerRepository.FindMany();

            foreach (var customer in customers)
            {
                System.Console.WriteLine(string.Format("Customer : Id={0}, Name={1}, Birth date={2}",
                                                       customer.Id, customer.CustomerName, customer.BirthDate));
            }
        }

    }
}
