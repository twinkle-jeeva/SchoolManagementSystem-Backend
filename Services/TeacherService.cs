using AutoMapper;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.Models;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;
    private readonly IMapper _mapper;

    public TeacherService(ITeacherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TeacherDto>> GetAllAsync()
    {
        var teachers = await _repository.GetAllAsync();
        return _mapper.Map<List<TeacherDto>>(teachers);
    }

    public async Task<TeacherDto?> GetByIdAsync(int id)
    {
        var teacher = await _repository.GetByIdAsync(id);
        return teacher == null ? null : _mapper.Map<TeacherDto>(teacher);
    }

    public async Task<TeacherDto> CreateAsync(TeacherCreateDto dto)
    {
        if (await _repository.EmailExistsAsync(dto.Email))
            throw new Exception("Email already exists.");

        var teacher = _mapper.Map<Teacher>(dto);

        await _repository.AddAsync(teacher);
        await _repository.SaveChangesAsync();

        return _mapper.Map<TeacherDto>(teacher);
    }

    public async Task<bool> UpdateAsync(int id, TeacherUpdateDto dto)
    {
        var teacher = await _repository.GetByIdAsync(id);
        if (teacher == null) return false;

        _mapper.Map(dto, teacher);

        _repository.Update(teacher);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var teacher = await _repository.GetByIdAsync(id);
        if (teacher == null) return false;

        _repository.Delete(teacher);
        await _repository.SaveChangesAsync();

        return true;
    }
}