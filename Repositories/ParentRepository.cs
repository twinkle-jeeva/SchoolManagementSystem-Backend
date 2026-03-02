using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Data;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly ApplicationDbContext _context;

        public ParentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Parent>> GetAllAsync()
        {
            return await _context.Parents
                .Include(p => p.EmergencyContacts)
                .ToListAsync();
        }

        public async Task<Parent?> GetByIdAsync(int id)
        {
            return await _context.Parents
                .Include(p => p.EmergencyContacts)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Parent parent)
        {
            await _context.Parents.AddAsync(parent);
        }

        public async Task UpdateAsync(Parent parent)
        {
            _context.Parents.Update(parent);
        }

        public async Task DeleteAsync(Parent parent)
        {
            _context.Parents.Remove(parent);
        }

        public async Task<bool> ExistsByStudentIdAsync(int studentId)
        {
            return await _context.Parents.AnyAsync(p => p.StudentId == studentId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}