﻿using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);

        Task<User> AddAsync(int id, string email, int passWord, string role);

        Task<User> UpdateAsync(User user);

        Task DeleteAsync(int id);
    }
}
