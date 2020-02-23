using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // GET api/customer
        [HttpGet]
        [TypeFilter(typeof(ValidateMaxItemsFilter))]
        public IEnumerable<Customer> Get()
        {
            var criteria = new CustomerCriteria();
            return _customerReadableRepository.FindMany(criteria);
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public Customer Get([Range(1, 1000)]int id)
        {
            var criteria = new CustomerCriteria
            {
                Id = id
            };
            return _customerReadableRepository.Find(criteria);
        }

        // GET api/customer/code/A
        [HttpGet("code/{customerCode}")]
        [TypeFilter(typeof(ValidateMaxItemsFilter))]
        public IEnumerable<Customer> Get(string customerCode)
        {
            var criteria = new CustomerCriteria
            {
                CustomerCode = customerCode
            };
            return _customerReadableRepository.FindMany(criteria);
        }

        // POST api/customer
        [HttpPost]
        public void Post([FromBody]Customer value)
        {
            _customerWritableRepository.Insert(value);
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Customer value)
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
            _customerWritableRepository.Update(entity);
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var criteria = new CustomerCriteria
            {
                Id = id
            };
            _customerWritableRepository.Delete(criteria);
        }
    }
}
