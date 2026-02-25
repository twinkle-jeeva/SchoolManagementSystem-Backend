using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories.Interfaces;
using StudentDemoAPI.Data;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);

        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

        public async Task<User?> GetByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();

        public async Task<bool> ExistsByEmailAsync(string email) =>
            await _context.Users.AnyAsync(u => u.Email == email);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}