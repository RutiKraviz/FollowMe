using AutoMapper;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Repositories;
using MyProject.Services.Interraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class StationService : IStationInterface
    {
        private readonly StationRepository _ststionRepository;
        private readonly IMapper _mapper;

        public StationService(StationRepository stationRepository, IMapper mapper)
        {
            _ststionRepository = stationRepository;
            _mapper = mapper;
        }
        public async Task<StationDTO> AddAsync(StationDTO station)
        {
            return _mapper.Map<StationDTO>(await _ststionRepository.AddAsync(station.Id, station.Address, station.RouteId));
        }

        public async Task DeleteAsync(int id)
        {
           await _ststionRepository.DeleteAsync(id);
        }

        public async Task<StationDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<StationDTO>(await _ststionRepository.GetByIdAsync(id));
        }

        public async Task<StationDTO> UpdateAsync(StationDTO station)
        {
            return _mapper.Map<StationDTO>(await _ststionRepository.UpdateAsync(_mapper.Map<Station>(station)));
        }
    }
}
