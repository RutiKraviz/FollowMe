using MyProject.Common.DTOs;
using MyProject.Repositories.Entities.MyProject.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IDriverService
    {
        Task<DriverDTO> GetByIdAsync(int userId);
        Task<DriverDTO> AddAsync(DriverDTO driverModel);
        Task<DriverDTO> UpdateAsync(DriverDTO driverModel);
        Task DeleteAsync(int userId);
    }
}
