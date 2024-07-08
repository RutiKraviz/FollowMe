using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Services.Interfaces;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly MyDbContext _context;

    public UserService(IUserRepository userRepository, IMapper mapper, MyDbContext context)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<UserDTO> AddAsync(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);

        // Detach any existing instances with the same primary key
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser != null)
        {
            _context.Entry(existingUser).State = EntityState.Detached;
        }

        return _mapper.Map<UserDTO>(await _userRepository.AddAsync(user));
    }

    public async Task DeleteAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<UserDTO> GetByIdAsync(int id)
    {
        return _mapper.Map<UserDTO>(await _userRepository.GetByIdAsync(id));
    }

    public async Task<UserDTO> UpdateAsync(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);

        // Detach any existing instances with the same primary key
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser != null)
        {
            _context.Entry(existingUser).State = EntityState.Detached;
        }

        return _mapper.Map<UserDTO>(await _userRepository.UpdateAsync(user));
    }

    public async Task<UserDTO> Login(string name, string password)
    {
        return _mapper.Map<UserDTO>(await _userRepository.Login(name, password));
    }
}
