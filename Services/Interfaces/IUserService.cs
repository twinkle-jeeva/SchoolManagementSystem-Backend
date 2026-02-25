using StudentDemoAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserCreateDto dto);
        Task<UserDto?> GetByIdAsync(int id);
        Task<List<UserDto>> GetAllAsync();
    }
}