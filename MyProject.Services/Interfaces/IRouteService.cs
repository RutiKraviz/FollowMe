using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IRouteService
    {
        Task<RouteDTO> GetByIdAsync(int id);

        Task<RouteDTO> AddAsync(RouteDTO route);

        Task<RouteDTO> UpdateAsync(RouteDTO route);

        Task DeleteAsync(int id);
    }
}
