using StudentDemoAPI.Models;

public interface ITeacherRepository
{
    Task<List<Teacher>> GetAllAsync();
    Task<Teacher?> GetByIdAsync(int id);
    Task AddAsync(Teacher teacher);
    void Update(Teacher teacher);
    void Delete(Teacher teacher);
    Task<bool> EmailExistsAsync(string email);
    Task SaveChangesAsync();
    IQueryable<Teacher> GetQueryable();

}