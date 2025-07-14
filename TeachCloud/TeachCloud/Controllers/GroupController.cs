//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using TeachCloud.Core.DTOs;
//using TeachCloud.Core.Entities;
//using TeachCloud.Core.Service;
//using TeachCloud.Service;

//namespace TeachCloud.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class GroupController : ControllerBase
//    {
//        private readonly IGroupService _groupService;
//        private readonly IMapper _mapper;

//        public GroupController(IGroupService groupService, IMapper mapper)
//        {
//            _groupService = groupService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var groups = _groupService.GetAllGroups();
//            var groupDtos = _mapper.Map<List<GroupDto>>(groups);
//            return Ok(groupDtos);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var group = _groupService.GetGroupById(id);
//            if (group == null) return NotFound();
//            var groupDto = _mapper.Map<GroupDto>(group);
//            return Ok(groupDto);
//        }
//        [HttpGet("{id}/courses")]
//        [Authorize(Roles = "Teacher")]
//        public IActionResult GetCoursesForGroup(int id)
//        {
//            var group = _groupService.GetGroupById(id);
//            if (group == null) return NotFound();

//            var courses = new List<Course> { group.Course };
//            var courseDtos = _mapper.Map<List<CourseDto>>(courses);
//            return Ok(courseDtos);
//        }

//        //[HttpPost]
//        //public IActionResult Create([FromBody] GroupDto groupDto)
//        //{
//        //    var group = _mapper.Map<Group>(groupDto);
//        //    var createdGroup = _groupService.CreateGroup(group);
//        //    var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);
//        //    return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
//        //}

//        [HttpPost]
//        public IActionResult Create([FromBody] GroupDto groupDto)
//        {
//            var group = _mapper.Map<Group>(groupDto);

//            // 🛠 משיגים את הקורס מתוך ה־DB לפי ה־CourseId
//            var course = _courseService.GetCourseById(groupDto.CourseId);
//            if (course == null)
//                return BadRequest("Course not found");

//            group.Course = course;

//            var createdGroup = _groupService.CreateGroup(group);
//            var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);
//            return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
//        }

//        [HttpPut("{id}")]
//        public IActionResult Update(int id, [FromBody] GroupDto groupDto)
//        {
//            var group = _mapper.Map<Group>(groupDto);
//            var success = _groupService.UpdateGroup(id, group);
//            if (!success) return NotFound();
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var success = _groupService.DeleteGroup(id);
//            if (!success) return NotFound();
//            return NoContent();
//        }
//    }
//}


//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using TeachCloud.Core.DTOs;
//using TeachCloud.Core.Entities;
//using TeachCloud.Core.Service;

//namespace TeachCloud.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class GroupController : ControllerBase
//    {
//        private readonly IGroupService _groupService;
//        private readonly ICourseService _courseService; // ✅ חדש
//        private readonly IMapper _mapper;

//        // ✅ הוספנו את courseService ל־constructor
//        public GroupController(IGroupService groupService, ICourseService courseService, IMapper mapper)
//        {
//            _groupService = groupService;
//            _courseService = courseService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var groups = _groupService.GetAllGroups();
//            var groupDtos = _mapper.Map<List<GroupDto>>(groups);
//            return Ok(groupDtos);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var group = _groupService.GetGroupById(id);
//            if (group == null) return NotFound();
//            var groupDto = _mapper.Map<GroupDto>(group);
//            return Ok(groupDto);
//        }

//        [HttpGet("{id}/courses")]
//        [Authorize(Roles = "Teacher")]
//        public IActionResult GetCoursesForGroup(int id)
//        {
//            var group = _groupService.GetGroupById(id);
//            if (group == null) return NotFound();

//            var courses = new List<Course> { group.Course };
//            var courseDtos = _mapper.Map<List<CourseDto>>(courses);
//            return Ok(courseDtos);
//        }

//        //[HttpPost]
//        //public IActionResult Create([FromBody] GroupDto groupDto)
//        //{
//        //    var group = _mapper.Map<Group>(groupDto);

//        //    // ✅ משיגים את הקורס לפי CourseId
//        //    var course = _courseService.GetCourseById(groupDto.CourseId);
//        //    if (course == null)
//        //        return BadRequest("Course not found");

//        //    group.Course = course;

//        //    var createdGroup = _groupService.CreateGroup(group);
//        //    var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);
//        //    return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
//        //}

//        //[HttpPost]
//        //public IActionResult Create([FromBody] GroupDto groupDto)
//        //{
//        //    var group = _mapper.Map<Group>(groupDto);

//        //    var course = _courseService.GetCourseById(groupDto.CourseId);
//        //    if (course == null)
//        //        return BadRequest("Course not found");

//        //    group.Course = course;

//        //    var createdGroup = _groupService.CreateGroup(group);

//        //    // ✅ טוענים מחדש את הקבוצה מה־DB (כולל ה־Course)
//        //    var createdGroupFromDb = _groupService.GetGroupById(createdGroup.Id);

//        //    var createdGroupDto = _mapper.Map<GroupDto>(createdGroupFromDb);
//        //    return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
//        //}

//        [HttpPost]
//        public IActionResult Create([FromBody] GroupDto groupDto)
//        {
//            var group = _mapper.Map<Group>(groupDto);

//            var course = _courseService.GetCourseById(groupDto.CourseId);
//            if (course == null)
//                return BadRequest("Course not found");

//            group.Course = course;

//            var createdGroup = _groupService.CreateGroup(group);
//            var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);

//            return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
//        }



//        [HttpPut("{id}")]
//        public IActionResult Update(int id, [FromBody] GroupDto groupDto)
//        {
//            var group = _mapper.Map<Group>(groupDto);
//            var success = _groupService.UpdateGroup(id, group);
//            if (!success) return NotFound();
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var success = _groupService.DeleteGroup(id);
//            if (!success) return NotFound();
//            return NoContent();
//        }
//    }
//}




//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
//using TeachCloud.Core.DTOs;
//using TeachCloud.Core.Entities;
//using TeachCloud.Core.Service;
//using TeachCloud.Service;

//namespace TeachCloud.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class GroupController : ControllerBase
//    {
//        private readonly IGroupService _groupService;
//        private readonly IMapper _mapper;
//        private readonly ITeacherService _teacherService;
//        private readonly ICourseService _courseService;
//        private readonly IGroupCourseService _groupCourseService;


//        public GroupController(IGroupService groupService, IMapper mapper)
//        {
//            _groupService = groupService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var groups = _groupService.GetAllGroups();
//            var groupDtos = _mapper.Map<List<GroupDto>>(groups);
//            return Ok(groupDtos);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var group = _groupService.GetGroupById(id);
//            if (group == null) return NotFound();
//            var groupDto = _mapper.Map<GroupDto>(group);
//            return Ok(groupDto);
//        }

//        [HttpGet("{id}/courses")]
//        [Authorize(Roles = "Teacher")]
//        public IActionResult GetCoursesForGroup(int id)
//        {
//            var group = _groupService.GetGroupById(id);
//            if (group == null) return NotFound();

//            var courses = group.GroupCourses.Select(gc => gc.Course).ToList();
//            var courseDtos = _mapper.Map<List<CourseDto>>(courses);
//            return Ok(courseDtos);
//        }

//        [HttpPost]
//        public IActionResult Create([FromBody] GroupSimpleDto groupDto)
//        {
//            var group = _mapper.Map<Group>(groupDto);
//            var createdGroup = _groupService.CreateGroup(group);
//            var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);
//            return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
//        }


//        [HttpPost]
//        [Authorize(Roles = "Teacher")]
//        public IActionResult Create([FromBody] CreateGroupDto dto)
//        {


//            var email = User?.FindFirst(ClaimTypes.Email)?.Value;

//            var teacher = _teacherService.GetByEmail(email);
//            if (teacher == null)
//                return NotFound("Teacher not found");

//            var course = _courseService.GetById(dto.CourseId);
//            if (course == null)
//                return BadRequest("Course not found");

//            // יצירת קבוצה חדשה
//            var group = new Group
//            {
//                Name = dto.Name,
//                // נניח שאת מקשרת Admin לפי המורה — אם לא, תשאירי null
//                AdminId = null
//            };

//            var createdGroup = _groupService.CreateGroup(group);

//            // קישור לקורס דרך GroupCourse
//            var groupCourse = new GroupCourse
//            {
//                CourseId = dto.CourseId,
//                GroupId = createdGroup.Id
//            };
//            _groupCourseService.Create(groupCourse);

//            var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);
//            return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
//        }


//        [HttpPut("{id}")]
//        public IActionResult Update(int id, [FromBody] GroupSimpleDto groupDto)
//        {
//            var group = _mapper.Map<Group>(groupDto);
//            var success = _groupService.UpdateGroup(id, group);
//            if (!success) return NotFound();
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var success = _groupService.DeleteGroup(id);
//            if (!success) return NotFound();
//            return NoContent();
//        }
//    }
//}





//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
//using TeachCloud.Core.DTOs;
//using TeachCloud.Core.Entities;
//using TeachCloud.Core.Service;

//namespace TeachCloud.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class GroupController : ControllerBase
//    {
//        private readonly IGroupService _groupService;
//        private readonly IMapper _mapper;
//        private readonly ITeacherService _teacherService;
//        private readonly ICourseService _courseService;
//        private readonly IGroupCourseService _groupCourseService;

//        public GroupController(
//    IGroupService groupService,
//    IMapper mapper,
//    ITeacherService teacherService,
//    ICourseService courseService,
//    IGroupCourseService groupCourseService)
//        {
//            _groupService = groupService;
//            _mapper = mapper;
//            _teacherService = teacherService;
//            _courseService = courseService;
//            _groupCourseService = groupCourseService;
//        }


//        // GET api/group
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var groups = _groupService.GetAllGroups();
//            var groupDtos = _mapper.Map<List<GroupDto>>(groups);
//            return Ok(groupDtos);
//        }

//        // GET api/group/{id}
//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var group = _groupService.GetGroupById(id);
//            if (group == null) return NotFound();
//            var groupDto = _mapper.Map<GroupDto>(group);
//            return Ok(groupDto);
//        }

//        // GET api/group/{id}/courses
//        [HttpGet("{id}/courses")]
//        [Authorize(Roles = "Teacher")]
//        public IActionResult GetCoursesForGroup(int id)
//        {
//            var group = _groupService.GetGroupById(id);
//            if (group == null) return NotFound();

//            var courses = group.GroupCourses.Select(gc => gc.Course).ToList();
//            var courseDtos = _mapper.Map<List<CourseDto>>(courses);
//            return Ok(courseDtos);
//        }

//        // POST api/group
//        [HttpPost]
//        [Authorize(Roles = "Teacher")]
//        public IActionResult Create([FromBody] CreateGroupDto dto)
//        {
//            // אימות מטען הבקשה
//            if (string.IsNullOrWhiteSpace(dto.Name))
//                return BadRequest("Group name is required");

//            // אימות המורה
//            var email = User?.FindFirst(ClaimTypes.Email)?.Value;
//            if (string.IsNullOrEmpty(email))
//                return Unauthorized("Email not found in token");

//            var teacher = _teacherService.GetByEmail(email);
//            if (teacher == null)
//                return NotFound("Teacher not found");

//            // יצירת ישות הקבוצה
//            var group = new Group
//            {
//                Name = dto.Name,
//                AdminId = null  // או teacher.Id אם רוצים לקשר למנהל/יוצר
//            };
//            var createdGroup = _groupService.CreateGroup(group);

//            // קישור לקורס במידה ששלחו CourseId
//            if (dto.CourseId.HasValue)
//            {
//                var course = _courseService.GetById(dto.CourseId.Value);
//                if (course == null)
//                {
//                    // במידה וקורס לא נמצא, נמחק את הקבוצה שיצרנו או נחזיר שגיאה
//                    _groupService.DeleteGroup(createdGroup.Id);
//                    return BadRequest("Course not found");
//                }

//                var groupCourse = new GroupCourse
//                {
//                    GroupId = createdGroup.Id,
//                    CourseId = dto.CourseId.Value
//                };
//                _groupCourseService.Create(groupCourse);
//            }

//            var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);
//            return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
//        }

//        // PUT api/group/{id}
//        [HttpPut("{id}")]
//        public IActionResult Update(int id, [FromBody] GroupSimpleDto groupDto)
//        {
//            var group = _mapper.Map<Group>(groupDto);
//            var success = _groupService.UpdateGroup(id, group);
//            if (!success) return NotFound();
//            return NoContent();
//        }

//        // DELETE api/group/{id}
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var success = _groupService.DeleteGroup(id);
//            if (!success) return NotFound();
//            return NoContent();
//        }
//    }
//}



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

        //// POST api/group
        //[HttpPost]
        //[Authorize(Roles = "Teacher")]


        //public IActionResult Create([FromBody] CreateGroupDto dto)
        //{
        //    if (string.IsNullOrWhiteSpace(dto.Name))
        //        return BadRequest("Group name is required");

        //    var email = User?.FindFirst(ClaimTypes.Name)?.Value;
        //    if (string.IsNullOrEmpty(email))
        //        return Unauthorized("Email not found in token");

        //    var teacher = _teacherService.GetByEmail(email);
        //    if (teacher == null)
        //        return NotFound("Teacher not found");

        //    var group = new Group
        //    {
        //        Name = dto.Name,
        //        AdminId = null  // או teacher.Id אם תבחרי לשייך את המורה
        //    };

        //    var createdGroup = _groupService.CreateGroup(group);
        //    var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);
        //    return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
        //}

        //[HttpPost]
        //[Authorize]
        //public IActionResult Create([FromBody] CreateGroupDto dto)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(dto.Name))
        //            return BadRequest("Group name is required");

        //        var email = User?.FindFirst(ClaimTypes.Name)?.Value;
        //        if (string.IsNullOrEmpty(email))
        //            return Unauthorized("Email not found in token");

        //        var teacher = _teacherService.GetByEmail(email);
        //        if (teacher == null)
        //            return NotFound("Teacher not found");

        //        var group = new Group
        //        {
        //            Name = dto.Name,
        //            AdminId = null // או teacher.Id אם צריך
        //        };

        //        var createdGroup = _groupService.CreateGroup(group);
        //        var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);
        //        return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"😢 Server error: {ex.Message}");
        //    }
        //}


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
