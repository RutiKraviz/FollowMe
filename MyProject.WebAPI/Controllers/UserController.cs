﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
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
            return await _userService.UpdateAsync(new UserDTO() { Name = userModel.Name, PassWord = userModel.PassWord, Role = userModel.Role });
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Post(CustomerLoginModel login)
        {
            var Customer = await _userService.Login(login.Username, login.Password);
            if (Customer == null)
                return NotFound();
            return Customer;
        }
        [HttpPost]
        public async Task<UserDTO> Post([FromBody] UserModel userModel)
        {
            return await _userService.AddAsync(new UserDTO() { Name= userModel.Name, PassWord = userModel.PassWord, Role = userModel.Role});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
