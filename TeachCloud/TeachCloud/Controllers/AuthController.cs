//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Threading.Tasks;
//using TeachCloud.Core.DTOs;
//using TeachCloud.Core.Entities;
//using TeachCloud.Data;

//namespace TeachCloud.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public AuthController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
//        {
//            // בדיקה אם מישהו עם האימייל הזה כבר קיים
//            var existingStudent = await _context.Students.FirstOrDefaultAsync(u => u.Email == dto.Email);
//            var existingTeacher = existingStudent == null ? await _context.Teachers.FirstOrDefaultAsync(u => u.Email == dto.Email) : null;
//            var existingAdmin = (existingStudent == null && existingTeacher == null) ? await _context.Admins.FirstOrDefaultAsync(u => u.Email == dto.Email) : null;

//            if (existingStudent != null || existingTeacher != null || existingAdmin != null)
//            {
//                return Ok(new { exists = true });
//            }

//            User newUser;
//            switch (dto.Role)
//            {
//                case UserRole.Admin:
//                    newUser = new Admin
//                    {
//                        FullName = dto.FullName,
//                        Email = dto.Email,
//                        PasswordHash = dto.Password // בצע Hashing אמיתי!
//                    };
//                    _context.Admins.Add((Admin)newUser);
//                    break;

//                case UserRole.Teacher:
//                    newUser = new Teacher
//                    {
//                        FullName = dto.FullName,
//                        Email = dto.Email,
//                        PasswordHash = dto.Password
//                    };
//                    _context.Teachers.Add((Teacher)newUser);
//                    break;

//                default:
//                    newUser = new Student
//                    {
//                        FullName = dto.FullName,
//                        Email = dto.Email,
//                        PasswordHash = dto.Password
//                    };
//                    _context.Students.Add((Student)newUser);
//                    break;
//            }

//            await _context.SaveChangesAsync();

//            return Ok(new { success = true });
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Data;

namespace TeachCloud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            // בדיקה אם מישהו עם האימייל הזה כבר קיים באחת מהטבלאות
            var existingStudent = await _context.Students.FirstOrDefaultAsync(u => u.Email == dto.Email);
            var existingTeacher = existingStudent == null ? await _context.Teachers.FirstOrDefaultAsync(u => u.Email == dto.Email) : null;
            var existingAdmin = (existingStudent == null && existingTeacher == null)
                ? await _context.Admins.FirstOrDefaultAsync(u => u.Email == dto.Email) : null;

            if (existingStudent != null || existingTeacher != null || existingAdmin != null)
            {
                return Ok(new { exists = true });
            }

            // יצירת יוזר חדש לפי Role
            User newUser;
            switch (dto.Role)
            {
                case UserRole.Admin:
                    newUser = new Admin
                    {
                        FullName = dto.FullName,
                        Email = dto.Email,
                        PasswordHash = dto.Password, // כאן תוכל לשים בעתיד Hash
                    };
                    _context.Admins.Add((Admin)newUser);
                    break;

                case UserRole.Teacher:
                    newUser = new Teacher
                    {
                        FullName = dto.FullName,
                        Email = dto.Email,
                        PasswordHash = dto.Password
                    };
                    _context.Teachers.Add((Teacher)newUser);
                    break;

                case UserRole.Student:
                default:
                    newUser = new Student
                    {
                        FullName = dto.FullName,
                        Email = dto.Email,
                        PasswordHash = dto.Password
                    };
                    _context.Students.Add((Student)newUser);
                    break;
            }

            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }

    }
}