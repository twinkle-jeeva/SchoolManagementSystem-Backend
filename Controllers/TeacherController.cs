using Microsoft.AspNetCore.Mvc;
using StudentDemoAPI.DTOs;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _service;

    public TeacherController(ITeacherService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teachers = await _service.GetAllAsync();
        return Ok(teachers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var teacher = await _service.GetByIdAsync(id);
        if (teacher == null) return NotFound();
        return Ok(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TeacherCreateDto dto)
    {
        var teacher = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = teacher.Id }, teacher);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TeacherUpdateDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}