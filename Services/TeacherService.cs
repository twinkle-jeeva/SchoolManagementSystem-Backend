using AutoMapper;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.DTOs.Common;
using StudentDemoAPI.Models;
using StudentDemoAPI.Helpers;
using System.Security.Claims;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;
    private readonly IMapper _mapper;

    public TeacherService(ITeacherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
        public async Task<PagedResult<TeacherDto>> GetTeachersAsync(
    ClaimsPrincipal user,
    QueryParamsDto queryParams)
{
    var role = user.FindFirst(ClaimTypes.Role)?.Value;
    var email = user.FindFirst(ClaimTypes.Email)?.Value;

    IQueryable<Teacher> query = _repository.GetQueryable()
        .Include(t => t.Courses)
        .Include(t => t.Subjects);

    // Role-based access
    if (role == Roles.Teacher)
    {
        // Teachers only see their own record
        query = query.Where(t => t.Email == email);
    }
    // Admin sees all, no filter

    // 🔍 Search
    query = query.ApplySearch(queryParams.Search,
        t => t.FirstName,
        t => t.LastName,
        t => t.Email,
        t => t.Department,
        t => t.Education);

    // 🔃 Sorting
    if (queryParams.SortBy == "FullName")
    {
        query = queryParams.IsDescending
            ? query.OrderByDescending(t => t.FirstName + " " + t.LastName)
            : query.OrderBy(t => t.FirstName + " " + t.LastName);
    }
    else
    {
        query = query.ApplySorting(queryParams.SortBy, queryParams.IsDescending);
    }

    // Total count
    var total = await query.CountAsync();

    // Pagination + AutoMapper projection
    var items = await query
        .ApplyPagination(queryParams.PageNumber, queryParams.PageSize)
        .ProjectTo<TeacherDto>(_mapper.ConfigurationProvider)
        .ToListAsync();

    return new PagedResult<TeacherDto>
    {
        Items = items,
        TotalCount = total,
        PageNumber = queryParams.PageNumber,
        PageSize = queryParams.PageSize
    };
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