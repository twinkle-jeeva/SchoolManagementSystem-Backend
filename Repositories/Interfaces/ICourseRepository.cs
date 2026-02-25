using StudentDemoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> AddAsync(Course course);
        Task<Course?> UpdateAsync(Course course);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}