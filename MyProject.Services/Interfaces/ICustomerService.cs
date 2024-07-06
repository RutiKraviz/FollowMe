using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetByIdAsync(int id);
        //Task<CustomerDTO> Login(string name,string Password);

        Task<CustomerDTO> AddAsync(CustomerDTO costumer);

        Task<CustomerDTO> UpdateAsync(CustomerDTO Customer);
        
        Task DeleteAsync(int id);
    }
}
