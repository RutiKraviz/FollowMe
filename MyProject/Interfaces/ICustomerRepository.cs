using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        //Task<Coustemer> Login(string name, string password);

        Task<Customer> AddAsync(Customer coustemer);

        Task<Customer> UpdateAsync(Customer coustemer);
        
        Task DeleteAsync(int id);
    }
}
