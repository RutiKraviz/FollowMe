using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;

public class CustomerService : ICustomerService
{
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly MyDbContext _context;

    public CustomerService(IUserRepository userRepository, ICustomerRepository customerRepository, IMapper mapper, MyDbContext context)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
        _mapper = mapper;
        _context = context;
    }

    public async Task<CustomerDTO> GetByIdAsync(int userId)
    {
        var customer = await _customerRepository.GetByIdAsync(userId);
        if (customer == null)
        {
            throw new InvalidOperationException("Customer not found");
        }
        return _mapper.Map<CustomerDTO>(customer);
    }

    public async Task<CustomerDTO> AddAsync(CustomerDTO customerDto)
    {
        var user = _mapper.Map<User>(customerDto);

        // Detach any existing instances with the same primary key
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser != null)
        {
            _context.Entry(existingUser).State = EntityState.Detached;
        }

        await _userRepository.AddAsync(user);

        var customer = new Customer
        {
            Id = user.Id, // Ensure the same Id
            StationId = customerDto.StationId
        };

        var existingCustomer = await _context.Customers.FindAsync(customer.Id);
        if (existingCustomer != null)
        {
            _context.Entry(existingCustomer).State = EntityState.Detached;
        }

        await _customerRepository.AddAsync(customer);

        return _mapper.Map<CustomerDTO>(customer);
    }

    public async Task<CustomerDTO> UpdateAsync(CustomerDTO customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);

        // Detach any existing instances with the same primary key
        var existingCustomer = await _context.Customers.FindAsync(customer.Id);
        if (existingCustomer != null)
        {
            _context.Entry(existingCustomer).State = EntityState.Detached;
        }

        await _userRepository.UpdateAsync(customer);
        await _customerRepository.UpdateAsync(customer);
        return _mapper.Map<CustomerDTO>(customer);
    }

    public async Task DeleteAsync(int userId)
    {
        await _customerRepository.DeleteAsync(userId);
        await _userRepository.DeleteAsync(userId);
    }
}
