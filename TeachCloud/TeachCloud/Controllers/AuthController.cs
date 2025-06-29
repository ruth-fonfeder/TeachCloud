using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;
using TeachCloud.Data;
using Microsoft.AspNetCore.Identity; // נוספה

namespace TeachCloud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly PasswordHasher<User> _hasher;

        public AuthController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
            _hasher = new PasswordHasher<User>();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(u => u.Email == dto.Email);
            var existingTeacher = existingStudent == null ? await _context.Teachers.FirstOrDefaultAsync(u => u.Email == dto.Email) : null;
            var existingAdmin = (existingStudent == null && existingTeacher == null)
                ? await _context.Admins.FirstOrDefaultAsync(u => u.Email == dto.Email) : null;

            if (existingStudent != null || existingTeacher != null || existingAdmin != null)
            {
                return Ok(new { exists = true });
            }

            User newUser;
            switch (dto.Role)
            {
                case UserRole.Admin:
                    newUser = new Admin
                    {
                        FullName = dto.FullName,
                        Email = dto.Email,
                    };
                    newUser.PasswordHash = _hasher.HashPassword(newUser, dto.Password);
                    _context.Admins.Add((Admin)newUser);
                    break;

                case UserRole.Teacher:
                    newUser = new Teacher
                    {
                        FullName = dto.FullName,
                        Email = dto.Email,
                    };
                    newUser.PasswordHash = _hasher.HashPassword(newUser, dto.Password);
                    _context.Teachers.Add((Teacher)newUser);
                    break;

                case UserRole.Student:
                default:
                    newUser = new Student
                    {
                        FullName = dto.FullName,
                        Email = dto.Email,
                    };
                    newUser.PasswordHash = _hasher.HashPassword(newUser, dto.Password);
                    _context.Students.Add((Student)newUser);
                    break;
            }

            await _context.SaveChangesAsync();
            return Ok(new { success = true });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                Console.WriteLine("👉 התחלת login");
                Console.WriteLine("📧 אימייל שהגיע מהלקוח: " + dto.Email);

                User? user = null;

                var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == dto.Email);
                if (student != null) user = student;

                if (user == null)
                {
                    var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Email == dto.Email);
                    if (teacher != null) user = teacher;
                }

                if (user == null)
                {
                    var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Email == dto.Email);
                    if (admin != null) user = admin;
                }

                if (user == null)
                {
                    Console.WriteLine("❌ משתמש לא נמצא");
                    return Unauthorized("Invalid email or password");
                }

                // בדיקת סיסמה
                Console.WriteLine("🔑 בודקת סיסמה");
                var hasher = new PasswordHasher<User>();
                var result = hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
                if (result == PasswordVerificationResult.Failed)
                {
                    Console.WriteLine("❌ סיסמה לא נכונה");
                    return Unauthorized("Invalid email or password");
                }

                Console.WriteLine("✅ התחברות הצליחה, יוצרת טוקן");

                var token = _tokenService.CreateToken(user);

                return Ok(new
                {
                    role = user.Role.ToString(),
                    fullName = user.FullName,
                    token = token
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("🚨 שגיאה בהתחברות:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(500, "שגיאה פנימית בשרת");
            }
        }



        
    }
}
