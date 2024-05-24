using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interraces
{
    public interface IDriverinterface
    {
        Task<DriverDTO> GetByIdAsync(int id);

        Task<DriverDTO> AddAsync(DriverDTO driver);

        Task<DriverDTO> UpdateAsync(DriverDTO driver);

        Task DeleteAsync(int id);
    }
}
