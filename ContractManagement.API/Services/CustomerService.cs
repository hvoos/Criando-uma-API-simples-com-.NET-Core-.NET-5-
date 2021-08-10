using ContractManagement.API.Data;
using ContractManagement.API.Entities;
using ContractManagement.API.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManagement.API.Services
{
    public class CustomerService : ICustomer
    {
        private ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return new Customer();
            }

            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            try
            {
                _context.Entry(customer).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return customer;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;    
            }
        }
    }
}
