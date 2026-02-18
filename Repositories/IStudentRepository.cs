using System;
using StudentDemoAPI.Models;

namespace StudentDemoAPI.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        Task<List<Club>> GetClubsByIdsAsync(List<int> ids);

        

    }
}