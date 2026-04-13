using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Data;
using StudentDemoAPI.Models;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext _context;

    public TeacherRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>> GetAllAsync()
    {
        return await _context.Teachers
            .Include(t => t.Courses)
            .Include(t => t.Subjects)
            .ToListAsync();
    }

    public async Task<Teacher?> GetByIdAsync(int id)
    {
        return await _context.Teachers
            .Include(t => t.Courses)
            .Include(t => t.Subjects)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Teacher teacher)
    {
        await _context.Teachers.AddAsync(teacher);
    }

    public void Update(Teacher teacher)
    {
        _context.Teachers.Update(teacher);
    }

    public void Delete(Teacher teacher)
    {
        _context.Teachers.Remove(teacher);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Teachers.AnyAsync(t => t.Email == email);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public IQueryable<Teacher> GetQueryable()
{
    return _context.Teachers.AsQueryable();
}


}