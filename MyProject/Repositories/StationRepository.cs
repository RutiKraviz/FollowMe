using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;

namespace MyProject.Repositories.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly IContext _context;

        public StationRepository(IContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Station>> GetAllAsync()
        {
            return await _context.Stations.ToListAsync();
        }

        public async Task<Station> AddAsync(Station station)
        {
            _context.Stations.Add(station);
            await _context.SaveChangesAsync();
            return station;
        }

        public async Task DeleteAsync(int id)
        {
            var station = await GetByIdAsync(id);
            if (station != null)
            {
                _context.Stations.Remove(station);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Station> GetByIdAsync(int id)
        {
            return await _context.Stations.FindAsync(id);
        }

        public async Task<List<Station>> GetByRouteIdAsync(int routeId)
        {
            return await _context.Stations.Where(s => s.RouteId == routeId).ToListAsync();
        }

        public async Task<Station> UpdateAsync(Station station)
        {
            var s = GetByIdAsync(station.Id).Result;
            s.Id = station.Id;
            s.FullAddress = station.FullAddress;
            await _context.SaveChangesAsync();
            return s;
        }
    }
}