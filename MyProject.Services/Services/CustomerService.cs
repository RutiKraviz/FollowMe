using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyProject.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly MyDbContext _context;

        public CustomerService(IMapper mapper, MyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CustomerDTO> GetByIdAsync(int userId)
        {
            var customer = await _context.Customers.FindAsync(userId);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found");
            }

            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> AddAsync(CustomerDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> UpdateAsync(CustomerDTO customerDto)
        {
            var customer = await _context.Customers.FindAsync(customerDto.Id);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found");
            }

            _mapper.Map(customerDto, customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task DeleteAsync(int userId)
        {
            var customer = await _context.Customers.FindAsync(userId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}