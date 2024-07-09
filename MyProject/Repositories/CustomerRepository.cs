using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;

public class CustomerRepository : ICustomerRepository
{
    private readonly IContext _context;

    public CustomerRepository(IContext context)
    {
        _context = context;
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        return customer;
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        // Check if the customer already exists
        var existingCustomer = await _context.Customers.FindAsync(customer.Id);
        if (existingCustomer == null)
        {
            var res = _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return res.Entity;
        }
        return existingCustomer;
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        var result = _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return result.Entity;

    }

    public async Task DeleteAsync(int id)
    {
        var customer = await GetByIdAsync(id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}
