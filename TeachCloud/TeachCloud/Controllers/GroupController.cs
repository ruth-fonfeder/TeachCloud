using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_groupService.GetAllGroups());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var group = _groupService.GetGroupById(id);
            if (group == null) return NotFound();
            return Ok(group);
        }

        [HttpPost]
        public IActionResult Create(Group group)
        {
            var createdGroup = _groupService.CreateGroup(group);
            return CreatedAtAction(nameof(GetById), new { id = createdGroup.Id }, createdGroup);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Group group)
        {
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
