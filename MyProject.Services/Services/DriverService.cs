using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities.MyProject.Repositories.Entities;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;

public class DriverService : IDriverService
{
    private readonly IUserRepository _userRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;
    private readonly MyDbContext _context;

    public DriverService(IUserRepository userRepository, IDriverRepository driverRepository, IMapper mapper, MyDbContext context)
    {
        _userRepository = userRepository;
        _driverRepository = driverRepository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<DriverDTO> GetByIdAsync(int userId)
    {
        var driver = await _driverRepository.GetByIdAsync(userId);
        if (driver == null)
        {
            throw new InvalidOperationException("Driver not found");
        }
        return _mapper.Map<DriverDTO>(driver);
    }

    public async Task<DriverDTO> AddAsync(DriverDTO driverDto)
    {
        var user = _mapper.Map<User>(driverDto);

        // Detach any existing instances with the same primary key
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser != null)
        {
            _context.Entry(existingUser).State = EntityState.Detached;
        }

        await _userRepository.AddAsync(user);

        var driver = new Driver
        {
            Id = user.Id, // Ensure the same Id
            RouteId = driverDto.RouteId
        };

        var existingDriver = await _context.Drivers.FindAsync(driver.Id);
        if (existingDriver != null)
        {
            _context.Entry(existingDriver).State = EntityState.Detached;
        }

        await _driverRepository.AddAsync(driver);

        return _mapper.Map<DriverDTO>(driver);
    }

    public async Task<DriverDTO> UpdateAsync(DriverDTO driverDto)
    {
        var driver = _mapper.Map<Driver>(driverDto);

        // Detach any existing instances with the same primary key
        var existingDriver = await _context.Drivers.FindAsync(driver.Id);
        if (existingDriver != null)
        {
            _context.Entry(existingDriver).State = EntityState.Detached;
        }

        await _userRepository.UpdateAsync(driver);
        await _driverRepository.UpdateAsync(driver);
        return _mapper.Map<DriverDTO>(driver);
    }

    public async Task DeleteAsync(int userId)
    {
        await _driverRepository.DeleteAsync(userId);
        await _userRepository.DeleteAsync(userId);
    }
}
