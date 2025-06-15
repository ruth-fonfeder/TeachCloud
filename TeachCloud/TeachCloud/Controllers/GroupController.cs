using AutoMapper;
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
        private readonly IMapper _mapper;

        public GroupController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
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

        [HttpPost]
        public IActionResult Create([FromBody] GroupDto groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
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
