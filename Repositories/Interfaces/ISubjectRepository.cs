using StudentDemoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllAsync();
        Task<Subject?> GetByIdAsync(int id);
        Task<Subject> AddAsync(Subject subject);
        Task<Subject?> UpdateAsync(Subject subject);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}