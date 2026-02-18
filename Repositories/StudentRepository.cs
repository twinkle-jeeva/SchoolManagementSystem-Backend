using System;
using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Data;
using StudentDemoAPI.Models;

namespace StudentDemoAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(s => s.Course)
                .Include(s => s.Clubs)
                .Include(s => s.Profile)
                .ToListAsync();
        }
        public async Task<List<Club>> GetClubsByIdsAsync(List<int> ids)
{
    return await _context.Clubs
        .Where(c => ids.Contains(c.Id))
        .ToListAsync();
}


        public async Task<Student> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Students
                .Include(s => s.Course)
                .Include(s => s.Clubs)
                .Include(s => s.Profile)
                .FirstOrDefaultAsync(s => s.Id == id);
#pragma warning restore CS8603 // Possible null reference return.

        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public  Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
             return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var student = await GetByIdAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}