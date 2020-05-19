using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DataAccess.Net.Interfaces;
using WebAPIApplication.Net.Entities;
using WebAPIApplication.Net.Filters;

namespace WebAPIApplication.Net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IReadableRepository<Customer, CustomerCriteria> _customerReadableRepository;
        private readonly IWritableRepository<Customer, CustomerCriteria> _customerWritableRepository;

        public CustomersController(IReadableRepository<Customer, CustomerCriteria> customerReadableRepository,
                                   IWritableRepository<Customer, CustomerCriteria> customerWritableRepository)
        {
            _customerReadableRepository = customerReadableRepository;
            _customerWritableRepository = customerWritableRepository;
        }

        // GET api/customers
        [HttpGet]
        [TypeFilter(typeof(ValidateMaxItemsFilter))]
        public async Task<IEnumerable<Customer>> Get()
        {
            var criteria = new CustomerCriteria();
            return await _customerReadableRepository.FindMany(criteria);
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public async Task<Customer> Get([Range(1, 1000)]int id)
        {
            var criteria = new CustomerCriteria
            {
                Id = id
            };
            return await _customerReadableRepository.Find(criteria);
        }

        // GET api/customers/code/A
        [HttpGet("code/{customerCode}")]
        [TypeFilter(typeof(ValidateMaxItemsFilter))]
        public async Task<IEnumerable<Customer>> Get(string customerCode)
        {
            var criteria = new CustomerCriteria
            {
                CustomerCode = customerCode
            };
            return await _customerReadableRepository.FindMany(criteria);
        }

        // POST api/customers
        [HttpPost]
        public async Task Post([FromBody]Customer value)
        {
            await _customerWritableRepository.Insert(value);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]Customer value)
        {
            var entity = new Customer
            {
                Id = id,
                CustomerCode = value.CustomerCode,
                CustomerName = value.CustomerName,
                NAS = value.NAS,
                Amount = value.Amount,
                BirthDate = value.BirthDate,
                OtherDate = value.OtherDate
            };
            await _customerWritableRepository.Update(entity);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var criteria = new CustomerCriteria
            {
                Id = id
            };
            await _customerWritableRepository.Delete(criteria);
        }
    }
}
