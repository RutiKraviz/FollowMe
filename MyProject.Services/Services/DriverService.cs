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
    public class DriverService : IDriverinterface
    {
        private readonly DriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(DriverRepository driverRepository , IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }
        public async Task<DriverDTO> AddAsync(DriverDTO driver)
        {
            return _mapper.Map<DriverDTO>(await _driverRepository.AddAsync(driver.Id, driver.FirstName, driver.LastName, driver.Address, driver.City, driver.Email));
        }

        public async Task DeleteAsync(int id)
        {
            await _driverRepository.DeleteAsync(id);
        }

        public async Task<DriverDTO> GetByIdAsync(int id)
        {
           return _mapper.Map<DriverDTO>(await _driverRepository.GetByIdAsync(id));
        }

        public async Task<DriverDTO> UpdateAsync(DriverDTO driver)
        {
            return _mapper.Map<DriverDTO>(await _driverRepository.UpdateAsync(_mapper.Map<Driver>(driver)));
        }
    }
}
