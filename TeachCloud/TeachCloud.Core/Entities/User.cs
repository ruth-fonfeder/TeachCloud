using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TeachCloud.Core.Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; private set; }

        public User(UserRole role)
        {
            Role = role;
        }
    }

    public enum UserRole
    {
        Admin=0,
        Teacher=1,
        Student=2
    }
}