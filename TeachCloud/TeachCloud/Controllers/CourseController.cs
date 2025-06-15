using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;

namespace TeachCloud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = _courseService.GetAllCourses();
            var courseDtos = _mapper.Map<List<CourseDto>>(courses);
            return Ok(courseDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null) return NotFound();
            var courseDto = _mapper.Map<CourseDto>(course);
            return Ok(courseDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            var createdCourse = _courseService.CreateCourse(course);
            var createdCourseDto = _mapper.Map<CourseDto>(createdCourse);
            return CreatedAtAction(nameof(GetById), new { id = createdCourseDto.Id }, createdCourseDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            var success = _courseService.UpdateCourse(id, course);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _courseService.DeleteCourse(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}