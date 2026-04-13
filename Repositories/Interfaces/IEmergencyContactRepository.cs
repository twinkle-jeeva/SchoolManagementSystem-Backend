using StudentDemoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Repositories.Interfaces
{
    public interface IEmergencyContactRepository
    {
        Task<List<EmergencyContact>> GetAllAsync();
        Task<EmergencyContact?> GetByIdAsync(int id);
        Task AddAsync(EmergencyContact contact);
        Task UpdateAsync(EmergencyContact contact);
        Task DeleteAsync(EmergencyContact contact);
        Task SaveChangesAsync();
        IQueryable<EmergencyContact> GetQueryable();
    }
}