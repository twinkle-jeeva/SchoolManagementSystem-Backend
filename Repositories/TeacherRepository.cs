using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Data;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET all teachers
        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers
                .Include(t => t.Courses) // Include related courses
                .ToListAsync();
        }

        // GET teacher by Id
        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _context.Teachers
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        // CREATE teacher
        public async Task AddAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
        }

        // UPDATE teacher
        public Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            return Task.CompletedTask;
        }

        // DELETE teacher
        public async Task DeleteAsync(int id)
        {
            var teacher = await GetByIdAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
            }
        }

        // CHECK if teacher exists by email (case-insensitive)
        public async Task<bool> ExistsByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return await _context.Teachers
                .AnyAsync(t => t.Email.ToLower() == email.ToLower());
        }

        // SAVE changes
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}