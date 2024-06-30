using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IDriverRepository
    {
        Task<Driver> GetByIdAsync(int id);

        Task<Driver> AddAsync(int id, string firstName, string lastName, string fullAddress, string email);

        Task<Driver> UpdateAsync(Driver driver);

        Task DeleteAsync(int id);

    }
}
