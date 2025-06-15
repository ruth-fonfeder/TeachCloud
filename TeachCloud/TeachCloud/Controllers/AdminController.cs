using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;
using TeachCloud.Core.DTOs;
using AutoMapper;

namespace TeachCloud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        // Get all
        [HttpGet]
        public IActionResult GetAll()
        {
            var admins = _adminService.GetAllAdmins();
            var adminDtos = _mapper.Map<List<AdminDto>>(admins);
            return Ok(adminDtos);
        }

        // Get by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var admin = _adminService.GetAdminById(id);
            if (admin == null)
                return NotFound();

            var dto = _mapper.Map<AdminDto>(admin);
            return Ok(dto);
        }

        // Create
        [HttpPost]
        public IActionResult Create([FromBody] AdminDto adminDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var admin = _mapper.Map<Admin>(adminDto);
            var created = _adminService.CreateAdmin(admin);
            var resultDto = _mapper.Map<AdminDto>(created);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, resultDto);
        }

        // Update
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AdminDto adminDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var admin = _mapper.Map<Admin>(adminDto);
            var success = _adminService.UpdateAdmin(id, admin);
            if (!success)
                return NotFound();

            return NoContent(); // 204
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _adminService.DeleteAdmin(id);
            if (!success)
                return NotFound();

            return NoContent(); // 204
        }
    }
}
