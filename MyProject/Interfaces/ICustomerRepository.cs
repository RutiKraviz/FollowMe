using MyProject.Repositories.Entities;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    }
}
