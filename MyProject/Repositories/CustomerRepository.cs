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

    public async Task AddAsync(Customer customer)
    {
        // Check if the customer already exists
        var existingCustomer = await _context.Customers.FindAsync(customer.Id);
        if (existingCustomer == null)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var customer = await GetByIdAsync(id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}
