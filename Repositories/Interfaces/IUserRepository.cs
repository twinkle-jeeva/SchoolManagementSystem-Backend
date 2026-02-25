using StudentDemoAPI.Models;

namespace StudentDemoAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<List<User>> GetAllAsync();
        Task<bool> ExistsByEmailAsync(string email);
        Task SaveChangesAsync();
    }
}