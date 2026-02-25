using StudentDemoAPI.Models;

namespace StudentDemoAPI.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        Task<bool> ExistsByEmailAsync(string email);

    }
}