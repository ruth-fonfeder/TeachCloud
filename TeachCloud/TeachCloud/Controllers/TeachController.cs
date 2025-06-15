using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;
using AutoMapper;
using TeachCloud.Core.DTOs;

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teachers = _teacherService.GetAllTeachers();
            var teacherDtos = _mapper.Map<List<TeacherDto>>(teachers);
            return Ok(teacherDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            if (teacher == null)
                return NotFound();

            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            return Ok(teacherDto);
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            var createdTeacher = _teacherService.CreateTeacher(teacher);
            return CreatedAtAction(nameof(GetById), new { id = createdTeacher.Id }, createdTeacher);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Teacher teacher)
        {
            var success = _teacherService.UpdateTeacher(id, teacher);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _teacherService.DeleteTeacher(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
