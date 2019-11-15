using DataAccess.Net.Interfaces;
using UnderstandingDependencyInjection.Net.Entities;
using UnderstandingDependencyInjection.Net.Interfaces;

namespace UnderstandingDependencyInjection.Net.Implementation
{
    public class Worker : IWorker
    {
        private readonly IReadableRepository<Customer, Unused> _voidCustomerRepository;
        private readonly IReadableRepository<Customer, CustomerCriteria> _customerRepository;

        public Worker(ICtrlAccesDB accesBd, 
                      IReadableRepository<Customer, Unused> voidCustomerRepository,
                      IReadableRepository<Customer, CustomerCriteria> customerRepository)
        {
            this._customerRepository = customerRepository;
            this._voidCustomerRepository = voidCustomerRepository;
        }

        public void DoSomeWork()
        {
            var customers = this._customerRepository.Find(new CustomerCriteria { CustomerCode = "A" });

            foreach (var customer in customers)
            {
                System.Console.WriteLine(string.Format("Customer : Id={0}, Name={1}, Birth date={2}", 
                                                       customer.Id, customer.CustomerName, customer.BirthDate));
            }
        }

        public void DoSomeVoidWork()
        {
            var customers = this._voidCustomerRepository.Find(Unused.Instance);

            foreach (var customer in customers)
            {
                System.Console.WriteLine(string.Format("Customer : Id={0}, Name={1}, Birth date={2}", 
                                                       customer.Id, customer.CustomerName, customer.BirthDate));
            }
        }

    }
}
