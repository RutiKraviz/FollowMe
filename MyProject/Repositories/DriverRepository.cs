using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities.MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;

public class DriverRepository : IDriverRepository
{
    private readonly IContext _context;

    public DriverRepository(IContext context)
    {
        _context = context;
    }

    public async Task<Driver> GetByIdAsync(int id)
    {
        return await _context.Drivers.FindAsync(id);
    }

    public async Task AddAsync(Driver driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Driver driver)
    {
        _context.Drivers.Update(driver);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var driver = await GetByIdAsync(id);
        _context.Drivers.Remove(driver);
        await _context.SaveChangesAsync();
    }
}
