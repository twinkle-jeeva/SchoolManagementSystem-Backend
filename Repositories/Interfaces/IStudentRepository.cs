using StudentDemoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<List<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    Task AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(Student student);
    Task<bool> ExistsByEmailAsync(string email);
    Task SaveChangesAsync();
}