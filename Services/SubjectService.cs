using AutoMapper;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories;

namespace StudentDemoAPI.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SubjectDto>> GetAllAsync()
        {
            var subjects = await _repository.GetAllAsync();
            return _mapper.Map<List<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto?> GetByIdAsync(int id)
        {
            var subject = await _repository.GetByIdAsync(id);
            return subject == null ? null : _mapper.Map<SubjectDto>(subject);
        }

        public async Task<SubjectDto> CreateAsync(SubjectCreateDto dto)
        {
            var subject = _mapper.Map<Subject>(dto);
            var created = await _repository.AddAsync(subject);
            return _mapper.Map<SubjectDto>(created);
        }

        public async Task<SubjectDto?> UpdateAsync(int id, SubjectUpdateDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            var updated = await _repository.UpdateAsync(existing);

            return updated == null ? null : _mapper.Map<SubjectDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}