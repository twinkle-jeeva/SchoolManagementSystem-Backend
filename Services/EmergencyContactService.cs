using AutoMapper;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories.Interfaces;
using StudentDemoAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentDemoAPI.Services
{
    public class EmergencyContactService : IEmergencyContactService
    {
        private readonly IEmergencyContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public EmergencyContactService(IEmergencyContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<List<EmergencyContactDto>> GetAllAsync()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return _mapper.Map<List<EmergencyContactDto>>(contacts);
        }

        public async Task<EmergencyContactDto?> GetByIdAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            if (contact == null) return null;
            return _mapper.Map<EmergencyContactDto>(contact);
        }

        public async Task<EmergencyContactDto> CreateAsync(EmergencyContactCreateDto dto)
        {
            var contact = _mapper.Map<EmergencyContact>(dto);
            await _contactRepository.AddAsync(contact);
            await _contactRepository.SaveChangesAsync();
            return _mapper.Map<EmergencyContactDto>(contact);
        }

        public async Task<EmergencyContactDto?> UpdateAsync(int id, EmergencyContactUpdateDto dto)
        {
            var existing = await _contactRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing); // partial update

            await _contactRepository.UpdateAsync(existing);
            await _contactRepository.SaveChangesAsync();

            return _mapper.Map<EmergencyContactDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            if (contact == null) return false;

            await _contactRepository.DeleteAsync(contact);
            await _contactRepository.SaveChangesAsync();

            return true;
        }
    }
}