using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly IContext _context;

        public DriverRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Driver> AddAsync(int id, string firstName, string lastName, string fulllAddress, string email)
        {
            var d = new Driver() { Id = id, FirstName = firstName, LastName = lastName, FullAddress = fulllAddress, Email = email};
            _context.Driveres.Add(d);
            await _context.SaveChangesAsync();
            return d;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Driveres.Remove(GetByIdAsync(id).Result);
            await _context.SaveChangesAsync();
        }

        public async Task<Driver> GetByIdAsync(int id)
        {
            return _context.Driveres.FindAsync(id).Result;

        }

        public async Task<Driver> UpdateAsync(Driver driver)
        {
            var c = GetByIdAsync(driver.Id).Result;
            c.Id = driver.Id;
            c.FirstName = driver.FirstName;
            c.LastName = driver.LastName;
            c.FullAddress = driver.FullAddress;
            c.Email = driver.Email;
            await _context.SaveChangesAsync();
            return c;
        }
    }
}
