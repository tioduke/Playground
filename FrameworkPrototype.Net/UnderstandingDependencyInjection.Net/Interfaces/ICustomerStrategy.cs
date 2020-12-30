using System.Collections.Generic;
using System.Threading.Tasks;

using UnderstandingDependencyInjection.Net.Entities;

namespace UnderstandingDependencyInjection.Net.Interfaces
{
    public interface ICustomerStrategy
    {
        Task­<IEnumerable<Customer>> GetCustomers();
    }
}