using MyProject.Repositories.Entities;

namespace MyProject.Repositories.Interfaces
{
    public interface IStationRepository
    {
        Task<IEnumerable<Station>> GetAllAsync();
        Task<Station> GetByIdAsync(int id);
        Task<List<Station>> GetByRouteIdAsync(int routeId);
        Task<Station> AddAsync(Station station);
        Task<Station> UpdateAsync(Station station);
        Task DeleteAsync(int id);
    }
}