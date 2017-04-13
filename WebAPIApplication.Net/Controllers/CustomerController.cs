using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using DataAccess.Net.Interfaces;
using WebAPIApplication.Net.Entities;

namespace WebAPIApplication.Net.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IReadableRepository<Customer, CustomerCriteria> _customerReadableRepository;
        private readonly IWritableRepository<Customer, CustomerCriteria> _customerWritableRepository;

        public CustomerController(IReadableRepository<Customer, CustomerCriteria> customerReadableRepository,
                                  IWritableRepository<Customer, CustomerCriteria> customerWritableRepository)
        {
            this._customerReadableRepository = customerReadableRepository;
            this._customerWritableRepository = customerWritableRepository;
        }

        // GET api/customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var criteria = new CustomerCriteria();
            return this._customerReadableRepository.Find(criteria);
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var criteria = new CustomerCriteria 
            { 
                Id = id 
            };
            return this._customerReadableRepository.FindById(criteria);
        }

        // POST api/customer
        [HttpPost]
        public void Post([FromBody]Customer value)
        {
            this._customerWritableRepository.Insert(value);
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
            this._customerWritableRepository.Update(entity);
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var criteria = new CustomerCriteria 
            { 
                Id = id 
            };
            this._customerWritableRepository.Delete(criteria);
        }
    }
}
