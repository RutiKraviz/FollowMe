using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Services.Interfaces;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }
        [HttpPut]
        public async Task<UserDTO> Update([FromBody] UserModel userModel)
        {
            return await _userService.UpdateAsync(_mapper.Map<UserDTO>(userModel));
        }

        [HttpPost]
        public async Task<UserDTO> Post([FromBody] UserModel userModel)
        {
            return await _userService.AddAsync(_mapper.Map<UserDTO>(userModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
