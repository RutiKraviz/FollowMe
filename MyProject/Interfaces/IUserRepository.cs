using MyProject.Repositories.Entities;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> Login(string name, string password); // הוספת ההגדרה לפונקציה Login
    Task<User> AddAsync(User user);
    Task<User> UpdateAsync(User user);
    Task DeleteAsync(int id);
}
