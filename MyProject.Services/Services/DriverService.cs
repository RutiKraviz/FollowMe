using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities.MyProject.Repositories.Entities;
using MyProject.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyProject.Services
{
    public class DriverService : IDriverService
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public DriverService(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DriverDTO> GetByIdAsync(int userId)
        {
            var driver = await _context.Drivers.FindAsync(userId);
            if (driver == null)
            {
                throw new InvalidOperationException("Driver not found");
            }

            return _mapper.Map<DriverDTO>(driver);
        }

        public async Task<DriverDTO> AddAsync(DriverDTO driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);

            await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();

            return _mapper.Map<DriverDTO>(driver);
        }

        public async Task<DriverDTO> UpdateAsync(DriverDTO driverDto)
        {
            var driver = await _context.Drivers.FindAsync(driverDto.Id);
            if (driver == null)
            {
                throw new InvalidOperationException("Driver not found");
            }

            _mapper.Map(driverDto, driver);
            await _context.SaveChangesAsync();

            return _mapper.Map<DriverDTO>(driver);
        }

        public async Task DeleteAsync(int userId)
        {
            var driver = await _context.Drivers.FindAsync(userId);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                await _context.SaveChangesAsync();
            }
        }
    }
}