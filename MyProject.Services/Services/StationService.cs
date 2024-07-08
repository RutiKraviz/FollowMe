using AutoMapper;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        private readonly IMapper _mapper;

        public StationService(IStationRepository stationRepository, IMapper mapper)
        {
            _stationRepository = stationRepository;
            _mapper = mapper;
        }
        public async Task<StationDTO> AddAsync(StationDTO station)
        {
            return _mapper.Map<StationDTO>(await _stationRepository.AddAsync(new Station() { 
                Id = station.Id,
                FullAddress = station.FullAddress,
                RouteId = station.RouteId, 
                Lan = station.Lan, 
                Lat = station.Lat }));
        }

        public async Task DeleteAsync(int id)
        {
           await _stationRepository.DeleteAsync(id);
        }

        public async Task<StationDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<StationDTO>(await _stationRepository.GetByIdAsync(id));
        }

        public async Task<List<StationDTO>> GetByRouteIdAsync(int routeId)
        {
            var stations = await _stationRepository.GetByRouteIdAsync(routeId);
            return _mapper.Map<List<StationDTO>>(stations);
        }

        public async Task<StationDTO> UpdateAsync(StationDTO station)
        {
            return _mapper.Map<StationDTO>(await _stationRepository.UpdateAsync(_mapper.Map<Station>(station)));
        }
    }
}
