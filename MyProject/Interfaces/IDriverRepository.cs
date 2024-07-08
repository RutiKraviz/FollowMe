using MyProject.Repositories.Entities;
using MyProject.Repositories.Entities.MyProject.Repositories.Entities;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IDriverRepository
    {
        Task<Driver> GetByIdAsync(int id);
        Task AddAsync(Driver driver);
        Task UpdateAsync(Driver driver);
        Task DeleteAsync(int id);
    }
}
