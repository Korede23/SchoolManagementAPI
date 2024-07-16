using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.DTOs;
using SchoolManagementAPI.Interfaces.Services;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentAsync();
            return Ok(students);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(string id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if(student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudent(CreateStudentRequest request)
        {
            await _studentService.CreateStudentAsync(request);
            return CreatedAtAction(nameof(GetStudentById), new { id = request.Id }, request);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> UpdateStudent(string id, UpdateStudentRequest request)
        {
            try
            {
                await _studentService.UpdateStudentAsync(id, request);
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeleteStudent(string id)
        {
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}
