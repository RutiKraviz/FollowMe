using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IStationService
    {
        Task<StationDTO> GetByIdAsync(int id);
        Task<List<StationDTO>> GetByRouteIdAsync(int routeId);

        Task<StationDTO> AddAsync(StationDTO station);

        Task<StationDTO> UpdateAsync(StationDTO station);

        Task DeleteAsync(int id);
    }
}
