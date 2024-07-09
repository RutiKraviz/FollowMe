using MyProject.Common.DTOs;

namespace MyProject.Services.Interfaces
{
    public interface IStationService
    {
        Task<IEnumerable<StationDTO>> GetAllAsync();
        Task<StationDTO> GetByIdAsync(int id);
        Task<List<StationDTO>> GetByRouteIdAsync(int routeId);
        Task<StationDTO> AddAsync(StationDTO station);
        Task<StationDTO> UpdateAsync(StationDTO station);
        Task DeleteAsync(int id);
    }
}