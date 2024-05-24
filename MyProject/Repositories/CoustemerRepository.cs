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

        public async Task<Costumer> GetByIdAsync(int id)
        {
            return _context.Costumeres.FindAsync(id).Result;
        }

        public async Task<Costumer> AddAsync(int id, string firstName, string lastName, string address, string city, string email)
        {
            var c = new Costumer() { Id = id, FirstName = firstName, LastName = lastName, Address = address, City = city, Email = email };
            _context.Costumeres.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task<Costumer> UpdateAsync(Costumer coustemer)
        {
            var c = GetByIdAsync(coustemer.Id).Result;
            c.Id = coustemer.Id;
            c.Email = coustemer.Email;
            c.Address = coustemer.Address;
            c.City = coustemer.City;
            c.FirstName = coustemer.FirstName;
            c.LastName = coustemer.lastName;
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Costumeres.Remove(GetByIdAsync(id).Result);
            await _context.SaveChangesAsync();
        }
    }
}


