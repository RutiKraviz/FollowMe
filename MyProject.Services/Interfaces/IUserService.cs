﻿using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> AddAsync(UserDTO user);
        Task DeleteAsync(int id);
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserDTO> UpdateAsync(UserDTO user);
        Task<UserDTO> Login(string name, string password);
    }
}
