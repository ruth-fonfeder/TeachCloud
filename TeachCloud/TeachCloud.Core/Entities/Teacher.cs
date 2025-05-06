using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Entities
{
    public class Teacher : User
    {
        public Teacher() : base(UserRole.Teacher) { }
        public List<Course> Courses { get; set; } = new();
    }
}
