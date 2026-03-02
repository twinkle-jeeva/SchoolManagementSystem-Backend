using StudentDemoAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Services.Interfaces
{
    public interface IEmergencyContactService
    {
        Task<List<EmergencyContactDto>> GetAllAsync();
        Task<EmergencyContactDto?> GetByIdAsync(int id);
        Task<EmergencyContactDto> CreateAsync(EmergencyContactCreateDto dto);
        Task<EmergencyContactDto?> UpdateAsync(int id, EmergencyContactUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}