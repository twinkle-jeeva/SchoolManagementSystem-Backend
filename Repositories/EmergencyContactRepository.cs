using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Data;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories
{
    public class EmergencyContactRepository : IEmergencyContactRepository
    {
        private readonly ApplicationDbContext _context;

        public EmergencyContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmergencyContact>> GetAllAsync()
        {
            return await _context.EmergencyContacts.ToListAsync();
        }

        public async Task<EmergencyContact?> GetByIdAsync(int id)
        {
            return await _context.EmergencyContacts.FirstOrDefaultAsync(ec => ec.Id == id);
        }

        public async Task AddAsync(EmergencyContact contact)
        {
            await _context.EmergencyContacts.AddAsync(contact);
        }

        public async Task UpdateAsync(EmergencyContact contact)
        {
            _context.EmergencyContacts.Update(contact);
        }

        public async Task DeleteAsync(EmergencyContact contact)
        {
            _context.EmergencyContacts.Remove(contact);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public IQueryable<EmergencyContact> GetQueryable()
        {
          return _context.EmergencyContacts
        .Include(ec => ec.Parent)
            .ThenInclude(p => p.Students);
        }
    }
}