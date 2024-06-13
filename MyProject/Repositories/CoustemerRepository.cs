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
    public class CoustemerRepository : ICoustemerRepository
    {
        private readonly IContext _context;

        public CoustemerRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Coustemer> GetByIdAsync(int id)
        {
            return _context.Costumeres.FindAsync(id).Result;
        }

        public async Task<Coustemer> AddAsync(Coustemer coustemer)
        {
            _context.Costumeres.Add(coustemer);
            await _context.SaveChangesAsync();
            return coustemer;
        }

        public async Task<Coustemer> UpdateAsync(Coustemer coustemer)
        {
            var c = GetByIdAsync(coustemer.Id).Result;
            c.Id = coustemer.Id;
            c.Email = coustemer.Email;
            c.Address = coustemer.Address;
            c.City = coustemer.City;
            c.FirstName = coustemer.FirstName;
            c.LastName = coustemer.LastName;
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Costumeres.Remove(GetByIdAsync(id).Result);
            await _context.SaveChangesAsync();
        }

        public Task<Coustemer> Login(string name, string password)
        {
           return  _context.Costumeres.FirstOrDefaultAsync(x=>x.FirstName==name&&x.Email==password);
        }
    }
}


