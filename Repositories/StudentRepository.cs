using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Data;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        // Include Course for CourseName mapping
        return await _context.Students
            .Include(s => s.Course)
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students
            .Include(s => s.Course)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
    }

    public async Task DeleteAsync(Student student)
    {
        _context.Students.Remove(student);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await _context.Students.AnyAsync(s => s.Email == email);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}