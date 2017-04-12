using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using DataAccess.Net.Interfaces;
using WebAPIApplication.Net.Entities;

namespace WebAPIApplication.Net.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IReadableRepository<Customer, CustomerCriteria> _customerRepository;

        public CustomerController(IReadableRepository<Customer, CustomerCriteria> customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var criteria = new CustomerCriteria 
            { 
                Id = id 
            };
            return this._customerRepository.FindById(criteria);
        }

        // GET api/customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return this._customerRepository.Find(new CustomerCriteria());
        }

        // POST api/customer
        [HttpPost]
        public void Post([FromBody]Customer value)
        {
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Customer value)
        {
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
