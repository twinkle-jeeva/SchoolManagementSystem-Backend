using StudentDemoAPI.DTOs;

namespace StudentDemoAPI.Services
{
    public interface ISubjectService
    {
        Task<List<SubjectDto>> GetAllAsync();
        Task<SubjectDto?> GetByIdAsync(int id);
        Task<SubjectDto> CreateAsync(SubjectCreateDto dto);
        Task<SubjectDto?> UpdateAsync(int id, SubjectUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}