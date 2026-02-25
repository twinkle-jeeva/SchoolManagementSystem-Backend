using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Data;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories.Interfaces;


namespace StudentDemoAPI.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all subjects with related Course and Teacher
        public async Task<List<Subject>> GetAllAsync()
        {
            return await _context.Subjects
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .ToListAsync();
        }

        // Get subject by Id
        public async Task<Subject?> GetByIdAsync(int id)
        {
            return await _context.Subjects
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Add new subject
        public async Task<Subject> AddAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        // Update existing subject
        public async Task<Subject?> UpdateAsync(Subject subject)
        {
            var existing = await _context.Subjects.FindAsync(subject.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(subject);
            await _context.SaveChangesAsync();
            return existing;
        }

        // Delete subject by Id
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Subjects.FindAsync(id);
            if (existing == null) return false;

            _context.Subjects.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        // Check if subject exists
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Subjects.AnyAsync(s => s.Id == id);
        }
    }
}