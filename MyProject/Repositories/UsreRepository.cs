using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class UsreRepository : IUserRepository
    {
        private readonly IContext _context;

        public UsreRepository(IContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(int id1, string email1, int passWord1, string role1)
        {
            var u = new User() { Id = id1, Email = email1, PassWord = passWord1, Role = role1 };
            _context.Users.Add(u);
            await _context.SaveChangesAsync();
            return u;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Users.Remove(GetByIdAsync(id).Result);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return _context.Users.FindAsync(id).Result;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var u = GetByIdAsync(user.Id).Result;
            u.Id = user.Id;
            u.Email = user.Email;
            u.PassWord = user.PassWord;
            await _context.SaveChangesAsync();
            return u;
        }
    }
}
