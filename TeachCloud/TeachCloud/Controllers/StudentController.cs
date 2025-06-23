
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAllStudents();
            var studentDtos = _mapper.Map<List<StudentDto>>(students);
            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null) return NotFound();
            var studentDto = _mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] StudentDto studentDto)
        {
            var createdStudent = _studentService.CreateStudent(studentDto);
            var createdStudentDto = _mapper.Map<StudentDto>(createdStudent);
            return CreatedAtAction(nameof(GetById), new { id = createdStudentDto.Id }, createdStudentDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            var success = _studentService.UpdateStudent(id, student);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _studentService.DeleteStudent(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
