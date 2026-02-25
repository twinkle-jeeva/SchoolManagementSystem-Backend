using StudentDemoAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task<StudentDto> CreateAsync(StudentCreateDto dto);
        Task<StudentDto?> UpdateAsync(int id, StudentUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}