using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> Get(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return customer;
        }

        [HttpPost]
        //public async Task<CustomerDTO> Post([FromBody] CustomerModel customerModel)
        public async void Post([FromBody] CustomerModel customerModel)
        {
            var customerDto = _mapper.Map<CustomerDTO>(new CustomerDTO()
            {
                Id = customerModel.Id,
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                Email = customerModel.Email,
                PassWord = customerModel.PassWord,
                RoleId = 2,
                StationId = customerModel.StationId,
            });
            //return await _customerService.AddAsync(customerDto);
        }

        [HttpPut]
        public async Task<CustomerDTO> Update([FromBody] CustomerModel customerModel)
        {
            var customerDto = _mapper.Map<CustomerDTO>(new CustomerDTO()
            {
                Id = customerModel.Id,
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                Email = customerModel.Email,
                PassWord = customerModel.PassWord,
                RoleId = 2,
                StationId = customerModel.StationId,
            });
            return await _customerService.UpdateAsync(customerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
