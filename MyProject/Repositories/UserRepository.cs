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
    public class UserRepository : IUserRepository
    {
        private readonly IContext _context;

        public UserRepository(IContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(User user)
        {
            var u = new User() { Id = user.Id, Name = user.Name, PassWord = user.PassWord, Role = user.Role };
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
            u.Name = user.Name;
            u.PassWord = user.PassWord;
            await _context.SaveChangesAsync();
            return u;
        }

        public Task<User> Login(string name, string password)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Name == name && x.PassWord == password);
        }
    }
}
