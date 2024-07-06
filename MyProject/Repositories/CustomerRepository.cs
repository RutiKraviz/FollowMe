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
                return _context.Customers.FindAsync(id).Result;
            }

            public async Task<Customer> AddAsync(Customer Customer)
            {
                _context.Customers.Add(Customer);
                await _context.SaveChangesAsync();
                return Customer;
            }

            public async Task<Customer> UpdateAsync(Customer Customer)
            {
                var c = GetByIdAsync(Customer.Id).Result;
                c.Id = Customer.Id;
                c.Email = Customer.Email;
                c.FullAddress = Customer.FullAddress;
                c.FirstName = Customer.FirstName;
                c.LastName = Customer.LastName;
                await _context.SaveChangesAsync();
                return c;
            }

            public async Task DeleteAsync(int id)
            {
                _context.Customers.Remove(GetByIdAsync(id).Result);
                await _context.SaveChangesAsync();
            }

            //public Task<Customer> Login(string name, string password)
            //{
            //   return  _context.Costumeres.FirstOrDefaultAsync(x=>x.FirstName==name&&x.Email==password);
            //}
        }
    }


