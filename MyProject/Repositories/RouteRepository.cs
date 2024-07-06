using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Repositories.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly IContext _context;

        public RouteRepository(IContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Route> AddAsync(int id, List<Station> stations)
        {
            var r = new Route() { Id = id, Stations = stations };
            _context.Routes.Add(r);
            await _context.SaveChangesAsync();
            return r;
        }

        public async Task DeleteAsync(int id)
        {
            var route = await GetByIdAsync(id);
            if (route != null)
            {
                _context.Routes.Remove(route);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Route> GetByIdAsync(int id)
        {
            return await _context.Routes.Include(r => r.Stations)
                                        .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Route> UpdateAsync(Route route)
        {
            var existingRoute = await GetByIdAsync(route.Id);
            if (existingRoute != null)
            {
                existingRoute.Stations = route.Stations;
                await _context.SaveChangesAsync();
            }
            return existingRoute;
        }
    }
}
