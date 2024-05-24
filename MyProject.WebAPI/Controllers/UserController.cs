using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Services.Interraces;
using MyProject.WebAPI.Models;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userService;

        public UserController(IUserInterface userService)
        {
            _userService = userService;
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
            return await _userService.UpdateAsync(new UserDTO() { Id = userModel.Id, PassWord = userModel.PassWord, Email = userModel.Email, Role = userModel.Role });
        }

        [HttpPost]
        public async Task<UserDTO> Post([FromBody] UserModel userModel)
        {
            return await _userService.AddAsync(new UserDTO() { Id = userModel.Id, Email = userModel.Email, PassWord = userModel.PassWord, Role = userModel.Role });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
