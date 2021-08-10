using ContractManagement.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractManagement.API.Repositories
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAsync();
        Task<Customer> GetAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
    }
}
