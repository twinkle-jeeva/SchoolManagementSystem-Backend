using StudentDemoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories.Interfaces
{
    public interface IParentRepository
    {
        Task<List<Parent>> GetAllAsync();
        Task<Parent?> GetByIdAsync(int id);
        Task AddAsync(Parent parent);
        Task UpdateAsync(Parent parent);
        Task DeleteAsync(Parent parent);
        Task<bool> ExistsByStudentIdAsync(int studentId);
        Task SaveChangesAsync();
        IQueryable<Parent> GetQueryable();
    }
}