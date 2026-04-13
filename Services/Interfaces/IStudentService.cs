using StudentDemoAPI.DTOs;
using StudentDemoAPI.DTOs.Common;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Services.Interfaces
{
    public interface IStudentService
    {
        //Task<List<StudentDto>> GetAllAsync();
        Task<PagedResult<StudentDto>> GetStudentsAsync(
    ClaimsPrincipal user,
    QueryParamsDto request);
        Task<StudentDto?> GetByIdAsync(int id);
        Task<StudentDto> CreateAsync(StudentCreateDto dto);
        Task<StudentDto?> UpdateAsync(int id, StudentUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}