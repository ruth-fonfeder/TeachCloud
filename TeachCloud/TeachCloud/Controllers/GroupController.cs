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


using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly ICourseService _courseService; // ✅ חדש
        private readonly IMapper _mapper;

        // ✅ הוספנו את courseService ל־constructor
        public GroupController(IGroupService groupService, ICourseService courseService, IMapper mapper)
        {
            _groupService = groupService;
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var groups = _groupService.GetAllGroups();
            var groupDtos = _mapper.Map<List<GroupDto>>(groups);
            return Ok(groupDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var group = _groupService.GetGroupById(id);
            if (group == null) return NotFound();
            var groupDto = _mapper.Map<GroupDto>(group);
            return Ok(groupDto);
        }

        [HttpGet("{id}/courses")]
        [Authorize(Roles = "Teacher")]
        public IActionResult GetCoursesForGroup(int id)
        {
            var group = _groupService.GetGroupById(id);
            if (group == null) return NotFound();

            var courses = new List<Course> { group.Course };
            var courseDtos = _mapper.Map<List<CourseDto>>(courses);
            return Ok(courseDtos);
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] GroupDto groupDto)
        //{
        //    var group = _mapper.Map<Group>(groupDto);

        //    // ✅ משיגים את הקורס לפי CourseId
        //    var course = _courseService.GetCourseById(groupDto.CourseId);
        //    if (course == null)
        //        return BadRequest("Course not found");

        //    group.Course = course;

        //    var createdGroup = _groupService.CreateGroup(group);
        //    var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);
        //    return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
        //}

        //[HttpPost]
        //public IActionResult Create([FromBody] GroupDto groupDto)
        //{
        //    var group = _mapper.Map<Group>(groupDto);

        //    var course = _courseService.GetCourseById(groupDto.CourseId);
        //    if (course == null)
        //        return BadRequest("Course not found");

        //    group.Course = course;

        //    var createdGroup = _groupService.CreateGroup(group);

        //    // ✅ טוענים מחדש את הקבוצה מה־DB (כולל ה־Course)
        //    var createdGroupFromDb = _groupService.GetGroupById(createdGroup.Id);

        //    var createdGroupDto = _mapper.Map<GroupDto>(createdGroupFromDb);
        //    return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
        //}

        [HttpPost]
        public IActionResult Create([FromBody] GroupDto groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);

            var course = _courseService.GetCourseById(groupDto.CourseId);
            if (course == null)
                return BadRequest("Course not found");

            group.Course = course;

            var createdGroup = _groupService.CreateGroup(group);
            var createdGroupDto = _mapper.Map<GroupDto>(createdGroup);

            return CreatedAtAction(nameof(GetById), new { id = createdGroupDto.Id }, createdGroupDto);
        }



        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GroupDto groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            var success = _groupService.UpdateGroup(id, group);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _groupService.DeleteGroup(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
