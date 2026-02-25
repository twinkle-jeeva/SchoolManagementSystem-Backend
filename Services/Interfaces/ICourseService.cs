using StudentDemoAPI.DTOs;

namespace StudentDemoAPI.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAllAsync();
        Task<CourseDto?> GetByIdAsync(int id);
        Task<CourseDto> CreateAsync(CourseCreateDto dto);
        Task<CourseDto?> UpdateAsync(int id, CourseUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}