using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetByIdAsync(int userId);
        Task<CustomerDTO> AddAsync(CustomerDTO customerModel);
        Task<CustomerDTO> UpdateAsync(CustomerDTO customerModel);
        Task DeleteAsync(int userId);
    }
}
