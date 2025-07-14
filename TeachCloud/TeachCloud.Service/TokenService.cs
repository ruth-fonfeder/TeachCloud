//using System.Security.Claims;
//using System.Text;
//using TeachCloud.Core.Entities;
//using TeachCloud.Core.Service;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using Microsoft.Extensions.Configuration;

//namespace TeachCloud.Service
//{
//    public class TokenService : ITokenService
//    {
//        private readonly IConfiguration _config;

//        public TokenService(IConfiguration config)
//        {
//            _config = config;
//        }

//        public string CreateToken(User user)
//        {
//            var claims = new[]
//            {
//                new Claim(ClaimTypes.Name, user.Email),               // ✅ שם המשתמש יהיה כתובת המייל
//                //new Claim("FullName", user.FullName),                 // ✅ שומר גם את השם המלא (אופציונלי)
//                new Claim(ClaimTypes.Role, user.Role.ToString())      // ✅ שומר את התפקיד (Teacher/Admin וכו')
//            };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                issuer: _config["JwtSettings:Issuer"],
//                audience: _config["JwtSettings:Audience"],
//                claims: claims,
//                expires: DateTime.UtcNow.AddHours(1),
//                signingCredentials: creds
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }
//}



using System.Security.Claims;
using System.Text;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace TeachCloud.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            // ⚠ הגנה מפני null
            var secret = _config["JwtSettings:SecretKey"];
            if (string.IsNullOrWhiteSpace(secret))
                throw new InvalidOperationException("Missing JWT SecretKey in configuration");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
