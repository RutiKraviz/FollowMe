using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly IContext _context;
        public StationRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Station> AddAsync(int id, double latitude, double longitude)
        {
            var s = new Station() { Id = id, Latitude = latitude,Longitude = longitude };
            _context.Stations.Add(s);
            await _context.SaveChangesAsync();
            return s;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Stations.Remove(GetByIdAsync(id).Result);
            await _context.SaveChangesAsync();
        }

        public async Task<Station> GetByIdAsync(int id)
        {
            return _context.Stations.FindAsync(id).Result;
        }

        public async Task<Station> UpdateAsync(Station station)
        {
            var s = GetByIdAsync(station.Id).Result;
            s.Id = station.Id;
            s.Latitude = s.Latitude;
            s.Longitude = station.Longitude;
            await _context.SaveChangesAsync();
            return s;
        }
    }
}
