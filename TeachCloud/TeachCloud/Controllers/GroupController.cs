using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;
using TeachCloud.Data;

namespace TeachCloud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;
        private readonly ITeacherService _teacherService;
        private readonly ITeacherGroupService _teacherGroupService;
        private readonly DataContext _context;


        public GroupController(
            IGroupService groupService,
            IMapper mapper,
            ITeacherService teacherService,
            ITeacherGroupService teacherGroupService,
            DataContext context)
        {
            _groupService = groupService;
            _mapper = mapper;
            _teacherService = teacherService;
            _teacherGroupService = teacherGroupService;
            _context = context;
        }

        // GET api/group
        [HttpGet]
        public IActionResult GetAll()
        {
            var groups = _groupService.GetAllGroups();
            var groupDtos = _mapper.Map<List<GroupDto>>(groups);
            return Ok(groupDtos);
        }

        // GET api/group/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var group = _groupService.GetGroupById(id);
            if (group == null) return NotFound();
            var groupDto = _mapper.Map<GroupDto>(group);
            return Ok(groupDto);
        }

        // GET api/group/{id}/courses
        [HttpGet("{id}/courses")]
        [Authorize(Roles = "Teacher")]
        public IActionResult GetCoursesForGroup(int id)
        {
            var group = _groupService.GetGroupById(id);
            if (group == null) return NotFound();

            var courses = group.GroupCourses.Select(gc => gc.Course).ToList();
            var courseDtos = _mapper.Map<List<CourseDto>>(courses);
            return Ok(courseDtos);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create([FromBody] CreateGroupDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Group name is required");

            var email = User?.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(email))
                return Unauthorized("Email not found in token");

            var teacher = _teacherService.GetByEmail(email);
            if (teacher == null)
                return NotFound("Teacher not found");

            var group = new Group
            {
                Name = dto.Name,
                AdminId = null // או teacher.Id אם תרצי
            };

            var createdGroup = _groupService.CreateGroup(group);

            // ✅ מוסיפים קשר רק אם הוא לא קיים כבר
            var existingRelation = _context.TeacherGroups
                .Any(tg => tg.TeacherId == teacher.Id && tg.GroupId == createdGroup.Id);

            if (!existingRelation)
            {
                var teacherGroup = new TeacherGroup
                {
                    TeacherId = teacher.Id,
                    GroupId = createdGroup.Id
                };

                _context.TeacherGroups.Add(teacherGroup);
                _context.SaveChanges();
            }

            var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);
            return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
        }

        // POST api/group/{groupId}/courses
        [HttpPost("{groupId}/courses")]
        [Authorize(Roles = "Teacher")]
        public IActionResult CreateCourseForGroup(int groupId, [FromBody] CreateCourseDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest("Course name is required");

            var group = _groupService.GetGroupById(groupId);
            if (group == null)
                return NotFound("Group not found");

            var course = new Course
            {
                Name = dto.Name
            };

            // שמירה בבסיס הנתונים
            _context.Courses.Add(course);
            _context.SaveChanges();

            // הוספת קשר לקבוצה
            var groupCourse = new GroupCourse
            {
                GroupId = groupId,
                CourseId = course.Id
            };

            _context.GroupCourses.Add(groupCourse);
            _context.SaveChanges();

            var courseDto = _mapper.Map<CourseDto>(course);
            return Created("", courseDto);
        }


        // PUT api/group/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GroupSimpleDto groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            var success = _groupService.UpdateGroup(id, group);
            if (!success) return NotFound();
            return NoContent();
        }

        // DELETE api/group/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _groupService.DeleteGroup(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
