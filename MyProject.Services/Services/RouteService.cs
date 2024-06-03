using AutoMapper;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class RouteService : IRouteInterface
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public RouteService(IRouteRepository routeRepository, IMapper mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }
        public async Task<RouteDTO> AddAsync(RouteDTO route)
        {
            var stations = _mapper.Map<Station>(route.Stations);
            return _mapper.Map<RouteDTO>(await _routeRepository.AddAsync(route.Id, stations));
        }

        public async Task DeleteAsync(int id)
        {
            await _routeRepository.DeleteAsync(id);
        }

        public async Task<RouteDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<RouteDTO>(await _routeRepository.GetByIdAsync(id));
        }

        public async Task<RouteDTO> UpdateAsync(RouteDTO route)
        {
            return _mapper.Map<RouteDTO>(await _routeRepository.UpdateAsync(_mapper.Map<Route>(route)));
        }
    }
}
