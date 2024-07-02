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

        public CustomerController(ICustomerService coustemerService, IMapper mapper)
        {
            _customerService = coustemerService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> Get(int id)
        {
            var coustemer = await _customerService.GetByIdAsync(id);
            if (coustemer == null)
                return NotFound();
            return coustemer;
        }
        //[HttpPost("Login")]
        //public async Task<ActionResult<CoustemerDTO>> Post(CoustemerLoginModel login)
        //{
        //    var coustemer = await _customerService.Login(login.Username, login.Password);
        //    if (coustemer == null)
        //        return NotFound();
        //    return coustemer;
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
