using AutoMapper;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IStationRepository _stationRepository;
        private readonly IMapper _mapper;

        public RouteService(IRouteRepository routeRepository, IStationRepository stationRepository, IMapper mapper)
        {
            _routeRepository = routeRepository ?? throw new ArgumentNullException(nameof(routeRepository));
            _stationRepository = stationRepository ?? throw new ArgumentNullException(nameof(stationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RouteDTO> AddAsync(RouteDTO route)
        {
            if (route == null) throw new ArgumentNullException(nameof(route));
            var stations = _mapper.Map<List<Station>>(route.Stations);
            return _mapper.Map<RouteDTO>(await _routeRepository.AddAsync(route.Id, stations, route.StartTime));
        }

        public async Task DeleteAsync(int id)
        {
            await _routeRepository.DeleteAsync(id);
        }

        public async Task<RouteDTO> GetByIdAsync(int id)
        {
            var route = await _routeRepository.GetByIdAsync(id);
            if (route == null)
            {
                return null;
            }

            var routeDTO = _mapper.Map<RouteDTO>(route);

            // Fetch and include stations
            var stations = await _stationRepository.GetByRouteIdAsync(route.Id);
            routeDTO.Stations = _mapper.Map<List<StationDTO>>(stations);

            return routeDTO;
        }

        public async Task<RouteDTO> UpdateAsync(RouteDTO route)
        {
            if (route == null) throw new ArgumentNullException(nameof(route));
            return _mapper.Map<RouteDTO>(await _routeRepository.UpdateAsync(_mapper.Map<Route>(route)));
        }
    }
}
