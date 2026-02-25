using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Data;
using StudentDemoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses
                                 .Include(c => c.Subjects)
                                 .Include(c => c.Students)
                                 .ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses
                                 .Include(c => c.Subjects)
                                 .Include(c => c.Students)
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course> AddAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course?> UpdateAsync(Course course)
        {
            var existing = await _context.Courses.FindAsync(course.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(course);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Courses.FindAsync(id);
            if (existing == null) return false;

            _context.Courses.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Courses.AnyAsync(c => c.Id == id);
        }
    }
}