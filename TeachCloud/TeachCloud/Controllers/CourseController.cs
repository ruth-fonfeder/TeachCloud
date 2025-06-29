//using Microsoft.AspNetCore.Mvc;
//using AutoMapper;
//using TeachCloud.Core.DTOs;
//using TeachCloud.Core.Entities;
//using TeachCloud.Core.Service;
//using Microsoft.AspNetCore.Authorization;
//using TeachCloud.Service;

//namespace TeachCloud.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CourseController : ControllerBase
//    {
//        private readonly ICourseService _courseService;
//        private readonly IMapper _mapper;

//        public CourseController(ICourseService courseService, IMapper mapper)
//        {
//            _courseService = courseService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var courses = _courseService.GetAllCourses();
//            var courseDtos = _mapper.Map<List<CourseDto>>(courses);
//            return Ok(courseDtos);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var course = _courseService.GetCourseById(id);
//            if (course == null) return NotFound();
//            var courseDto = _mapper.Map<CourseDto>(course);
//            return Ok(courseDto);
//        }

//        //[HttpPost]
//        //public IActionResult Create([FromBody] CourseDto courseDto)
//        //{
//        //    var course = _mapper.Map<Course>(courseDto);
//        //    var createdCourse = _courseService.CreateCourse(course);
//        //    var createdCourseDto = _mapper.Map<CourseDto>(createdCourse);
//        //    return CreatedAtAction(nameof(GetById), new { id = createdCourseDto.Id }, createdCourseDto);
//        //}


//        [HttpPost("my")]
//        [Authorize(Roles = "Teacher")]
//        public IActionResult CreateCourseForTeacher([FromBody] CreateCourseDto courseDto)
//        {
//            var email = User?.Identity?.Name;
//            if (string.IsNullOrEmpty(email))
//                return Unauthorized();

//            var teacher = _teacherService.GetTeacherByEmail(email);
//            if (teacher == null)
//                return NotFound("Teacher not found");

//            var course = new Course
//            {
//                Name = courseDto.Name,
//                TeacherId = teacher.Id,
//                StudyGroups = courseDto.StudyGroups.Select(g => new Group
//                {
//                    Name = g.Name
//                }).ToList()
//            };

//            _courseService.CreateCourse(course);

//            var resultDto = _mapper.Map<CourseDto>(course);
//            return CreatedAtAction(nameof(GetById), new { id = resultDto.Id }, resultDto);
//        }

//        [HttpPut("{id}")]
//        public IActionResult Update(int id, [FromBody] CourseDto courseDto)
//        {
//            var course = _mapper.Map<Course>(courseDto);
//            var success = _courseService.UpdateCourse(id, course);
//            if (!success) return NotFound();
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var success = _courseService.DeleteCourse(id);
//            if (!success) return NotFound();
//            return NoContent();
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;
using Microsoft.AspNetCore.Authorization;

namespace TeachCloud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public CourseController(
            ICourseService courseService,
            ITeacherService teacherService,
            IMapper mapper)
        {
            _courseService = courseService;
            _teacherService = teacherService;
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

        [HttpPost("my")]
        [Authorize(Roles = "Teacher")]
        public IActionResult CreateCourseForTeacher([FromBody] CreateCourseDto courseDto)
        {
            var email = User?.Identity?.Name;
            if (string.IsNullOrEmpty(email))
                return Unauthorized();

            var teacher = _teacherService.GetTeacherByEmail(email);
            if (teacher == null)
                return NotFound("Teacher not found");

            var course = new Course
            {
                Name = courseDto.Name,
                TeacherId = teacher.Id,
                StudyGroups = courseDto.StudyGroups.Select(g => new Group
                {
                    Name = g.Name
                }).ToList()
            };

            _courseService.CreateCourse(course);

            var resultDto = _mapper.Map<CourseDto>(course);
            return CreatedAtAction(nameof(GetById), new { id = resultDto.Id }, resultDto);
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
