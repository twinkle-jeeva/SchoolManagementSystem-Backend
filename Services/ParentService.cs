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
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;
        private readonly IMapper _mapper;

        public ParentService(IParentRepository parentRepository, IMapper mapper)
        {
            _parentRepository = parentRepository;
            _mapper = mapper;
        }

        public async Task<List<ParentDto>> GetAllAsync()
        {
            var parents = await _parentRepository.GetAllAsync();
            return _mapper.Map<List<ParentDto>>(parents);
        }

        public async Task<ParentDto?> GetByIdAsync(int id)
        {
            var parent = await _parentRepository.GetByIdAsync(id);
            if (parent == null) return null;
            return _mapper.Map<ParentDto>(parent);
        }

        public async Task<ParentDto> CreateAsync(ParentCreateDto dto)
        {
            var parent = _mapper.Map<Parent>(dto);
            await _parentRepository.AddAsync(parent);
            await _parentRepository.SaveChangesAsync();
            return _mapper.Map<ParentDto>(parent);
        }

        public async Task<ParentDto?> UpdateAsync(int id, ParentUpdateDto dto)
        {
            var existing = await _parentRepository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);

            await _parentRepository.UpdateAsync(existing);
            await _parentRepository.SaveChangesAsync();

            return _mapper.Map<ParentDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parent = await _parentRepository.GetByIdAsync(id);
            if (parent == null) return false;

            await _parentRepository.DeleteAsync(parent);
            await _parentRepository.SaveChangesAsync();
            return true;
        }
    }
}