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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IContext _context;

        public CustomerRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return _context.Custumeres.FindAsync(id).Result;
        }

        public async Task<Customer> AddAsync(Customer coustemer)
        {
            _context.Custumeres.Add(coustemer);
            await _context.SaveChangesAsync();
            return coustemer;
        }

        public async Task<Customer> UpdateAsync(Customer coustemer)
        {
            var c = GetByIdAsync(coustemer.Id).Result;
            c.Id = coustemer.Id;
            c.Email = coustemer.Email;
            c.FullAddress = coustemer.FullAddress;
            c.FirstName = coustemer.FirstName;
            c.LastName = coustemer.LastName;
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Custumeres.Remove(GetByIdAsync(id).Result);
            await _context.SaveChangesAsync();
        }

        //public Task<Coustemer> Login(string name, string password)
        //{
        //   return  _context.Costumeres.FirstOrDefaultAsync(x=>x.FirstName==name&&x.Email==password);
        //}
    }
}


