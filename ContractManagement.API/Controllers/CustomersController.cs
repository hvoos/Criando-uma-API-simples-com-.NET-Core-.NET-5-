using ContractManagement.API.Entities;
using ContractManagement.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomer _customer;

        public CustomersController(ICustomer customer) => _customer = customer;

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await _customer.GetAsync();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<Customer> GetAsync(int id)
        {
            return await _customer.GetAsync(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<Customer> CreateAsync([FromBody] Customer customer)
        {
            return await _customer.CreateAsync(customer);

        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<Customer> PutAsync([FromBody] Customer customer)
        {
            return await _customer.UpdateAsync(customer);
        }

    }
}
