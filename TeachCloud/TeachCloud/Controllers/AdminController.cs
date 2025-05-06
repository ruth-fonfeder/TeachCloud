using Microsoft.AspNetCore.Mvc;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;
using TeachCloud.Data;
using TeachCloud.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeachCloud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_adminService.GetAllAdmins());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var admin = _adminService.GetAdminById(id);
            if (admin == null) return NotFound();
            return Ok(admin);
        }

        [HttpPost]
        public IActionResult Create(Admin admin)
        {
            var created = _adminService.CreateAdmin(admin);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Admin admin)
        {
            var success = _adminService.UpdateAdmin(id, admin);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _adminService.DeleteAdmin(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}


