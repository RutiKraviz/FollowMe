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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private readonly IDriverService _driverService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper, ICustomerService customerService, IDriverService driverService)
        {
            _userService = userService;
            _mapper = mapper;
            _customerService = customerService;
            _driverService = driverService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] CustomerLoginModel login)
        {
            var user = await _userService.Login(login.Username, login.Password);
            if (user == null)
                return NotFound();

            if (user.RoleId == 1)
            {
                var driver = await _driverService.GetByIdAsync(user.Id);
                if (driver == null)
                    return NotFound();
                return Ok(driver);
            }
            else if (user.RoleId == 2)
            {
                var customer = await _customerService.GetByIdAsync(user.Id);
                if (customer == null)
                    return NotFound();
                return Ok(customer);
            }

            return BadRequest("Invalid role.");
        }

        [HttpPost]
        public async Task<UserDTO> Post([FromBody] UserModel userModel)
        {
            return await _userService.AddAsync(_mapper.Map<UserDTO>(userModel));
        }

        [HttpPut]
        public async Task<UserDTO> Update([FromBody] UserModel userModel)
        {
            return await _userService.UpdateAsync(_mapper.Map<UserDTO>(userModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
