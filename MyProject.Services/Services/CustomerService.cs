using AutoMapper;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository custemerRepository, IMapper mapper)
        {
            _customerRepository = custemerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDTO> AddAsync(CustomerDTO costumer)
        {
            return _mapper.Map<CustomerDTO>(await _customerRepository.AddAsync(_mapper.Map<Customer>(costumer)));
        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<CustomerDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CustomerDTO>(await _customerRepository.GetByIdAsync(id));
        }

        //public async Task<CoustemerDTO> Login(string name, string password)
        //{
        //    return _mapper.Map<CoustemerDTO>(await _coustemerRepository.Login(name,password));
        //}

        public async Task<CustomerDTO> UpdateAsync(CustomerDTO coustemer)
        {
            return _mapper.Map<CustomerDTO>(await _customerRepository.UpdateAsync(_mapper.Map<Customer>(coustemer)));
        }
    }
}
