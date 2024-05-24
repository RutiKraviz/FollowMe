using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly IContext _context;

        public RouteRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Route> AddAsync(int id, string name, DateTime beginningTime)
        {
            var r = new Route() { Id = id, Name = name, BeginningTime = beginningTime };
            _context.Routes.Add(r);
            await _context.SaveChangesAsync();
            return r;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Routes.Remove(GetByIdAsync(id).Result);
            await _context.SaveChangesAsync();
        }

        public async Task<Route> GetByIdAsync(int id)
        {
            return _context.Routes.FindAsync(id).Result;
        }

        public async Task<Route> UpdateAsync(Route route)
        {
            var r = GetByIdAsync(route.Id).Result;
            r.Id = route.Id;
            r.Name = route.Name;
            r.BeginningTime = route.BeginningTime;
            await _context.SaveChangesAsync();
            return r;
        }
    }
}
