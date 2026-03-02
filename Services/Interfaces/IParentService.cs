using StudentDemoAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Services.Interfaces
{
    public interface IParentService
    {
        Task<List<ParentDto>> GetAllAsync();
        Task<ParentDto?> GetByIdAsync(int id);
        Task<ParentDto> CreateAsync(ParentCreateDto dto);
        Task<ParentDto?> UpdateAsync(int id, ParentUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}