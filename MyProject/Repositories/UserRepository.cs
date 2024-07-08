using Microsoft.EntityFrameworkCore;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;

public class UserRepository : IUserRepository
{
    private readonly IContext _context;

    public UserRepository(IContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> Login(string name, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.FirstName + " " + u.LastName == name && u.PassWord == password);
    }
}
