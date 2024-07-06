using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService CustomerService, IMapper mapper)
        {
            _customerService = CustomerService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> Get(int id)
        {
            var Customer = await _customerService.GetByIdAsync(id);
            if (Customer == null)
                return NotFound();
            return Customer;
        }
        //[HttpPost("Login")]
        //public async Task<ActionResult<CustomerDTO>> Post(CustomerLoginModel login)
        //{
        //    var Customer = await _customerService.Login(login.Username, login.Password);
        //    if (Customer == null)
        //        return NotFound();
        //    return Customer;
        //}
        [HttpPost]
        public async Task<CustomerDTO> Post([FromBody] CustomerModel coustemrModel)
        {
            return await _customerService.AddAsync(new CustomerDTO() { FirstName = coustemrModel.FirstName, LastName = coustemrModel.LastName, FullAddress = coustemrModel.FullAddress, Email = coustemrModel.Email});
        }
        [HttpPut]
        public async Task<CustomerDTO> Update([FromBody] CustomerModel coustemrModel)
        {
            return await _customerService.UpdateAsync(new CustomerDTO() { FirstName = coustemrModel.FirstName, LastName = coustemrModel.LastName, FullAddress = coustemrModel.FullAddress, Email = coustemrModel.Email });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
