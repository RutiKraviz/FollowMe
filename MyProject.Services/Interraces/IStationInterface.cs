using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interraces
{
    public interface IStationInterface
    {
        Task<StationDTO> GetByIdAsync(int id);

        Task<StationDTO> AddAsync(StationDTO station);

        Task<StationDTO> UpdateAsync(StationDTO station);

        Task DeleteAsync(int id);
    }
}
