using AutoMapper;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.Models;
using StudentDemoAPI.Repositories;

namespace StudentDemoAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var courses = await _repository.GetAllAsync();
            return _mapper.Map<List<CourseDto>>(courses);
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var course = await _repository.GetByIdAsync(id);
            return course == null ? null : _mapper.Map<CourseDto>(course);
        }

        public async Task<CourseDto> CreateAsync(CourseCreateDto dto)
        {
            var course = _mapper.Map<Course>(dto);
            var created = await _repository.AddAsync(course);
            return _mapper.Map<CourseDto>(created);
        }

        public async Task<CourseDto?> UpdateAsync(int id, CourseUpdateDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            var updated = await _repository.UpdateAsync(existing);

            return updated == null ? null : _mapper.Map<CourseDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}