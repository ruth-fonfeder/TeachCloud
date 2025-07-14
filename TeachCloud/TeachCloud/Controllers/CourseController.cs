//using Microsoft.AspNetCore.Mvc;
//using AutoMapper;
//using TeachCloud.Core.DTOs;
//using TeachCloud.Core.Entities;
//using TeachCloud.Core.Service;
//using TeachCloud.Core.Repositories; // חשוב להוסיף בשביל IGroupRepository
//using Microsoft.AspNetCore.Authorization;
//using System.Security.Claims;
//using System.Collections.Generic;
//using System.Linq;

//namespace TeachCloud.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CourseController : ControllerBase
//    {
//        private readonly ICourseService _courseService;
//        private readonly ITeacherService _teacherService;
//        private readonly IGroupRepository _groupRepository;
//        private readonly IMapper _mapper;

//        public CourseController(
//            ICourseService courseService,
//            ITeacherService teacherService,
//            IGroupRepository groupRepository,
//            IMapper mapper)
//        {
//            _courseService = courseService;
//            _teacherService = teacherService;
//            _groupRepository = groupRepository;
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

//        [HttpPost("my")]
//        [Authorize(Roles = "Teacher")]
//        public IActionResult CreateCourseForTeacher([FromBody] CreateCourseDto courseDto)
//        {
//            var email = User?.Identity?.Name;
//            if (string.IsNullOrEmpty(email)) return Unauthorized();

//            var teacher = _teacherService.GetTeacherByEmail(email);
//            if (teacher == null) return NotFound("Teacher not found");

//            var studyGroups = new List<Group>();

//            foreach (var groupDto in courseDto.StudyGroups)
//            {
//                // חיפוש קבוצה קיימת עם אותו שם ו-adminId של המורה
//                var existingGroup = _groupRepository
//                    .GetAll()
//                    .FirstOrDefault(g => g.Name == groupDto.Name && g.AdminId == teacher.AdminId);

//                if (existingGroup != null)
//                {
//                    studyGroups.Add(existingGroup);
//                }
//                else
//                {
//                    var newGroup = new Group
//                    {
//                        Name = groupDto.Name,
//                        AdminId = teacher.AdminId
//                    };
//                    _groupRepository.Add(newGroup);
//                    studyGroups.Add(newGroup);
//                }
//            }

//            var course = new Course
//            {
//                Name = courseDto.Name,
//                TeacherId = teacher.Id,
//                StudyGroups = studyGroups
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
using TeachCloud.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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

        [HttpGet("my")]
        [Authorize(Roles = "Teacher")]
        public IActionResult GetMyCourses()
        {
            var email = User?.Identity?.Name;
            if (string.IsNullOrEmpty(email)) return Unauthorized();

            var teacher = _teacherService.GetTeacherByEmail(email);
            if (teacher == null) return NotFound("Teacher not found");

            var courses = _courseService.GetAllCourses()
                .Where(c => c.TeacherId == teacher.Id)
                .ToList();

            var dtos = _mapper.Map<List<CourseDto>>(courses);
            return Ok(dtos);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create([FromBody] CreateCourseDto courseDto)
        {
            var email = User?.Identity?.Name;
            if (string.IsNullOrEmpty(email)) return Unauthorized();

            var teacher = _teacherService.GetTeacherByEmail(email);
            if (teacher == null) return NotFound("Teacher not found");

            var course = new Course
            {
                Name = courseDto.Name,
                TeacherId = teacher.Id,
                GroupCourses = courseDto.Groups.Select(g => new GroupCourse
                {
                    GroupId = g.Id
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
