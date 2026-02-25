using Microsoft.AspNetCore.Mvc;
using StudentDemoAPI.DTOs;
using StudentDemoAPI.Services;

namespace StudentDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;

        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubjectDto>>> GetAll()
        {
            var subjects = await _service.GetAllAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetById(int id)
        {
            var subject = await _service.GetByIdAsync(id);
            if (subject == null)
                return NotFound();
            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult<SubjectDto>> Create([FromBody] SubjectCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubjectDto>> Update(int id, [FromBody] SubjectUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}