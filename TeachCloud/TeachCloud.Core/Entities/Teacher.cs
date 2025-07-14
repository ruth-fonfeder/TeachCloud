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
        public int? AdminId { get; set; }  // 👈 זה מאפשר ערך null

        public List<TeacherGroup> TeacherGroups { get; set; } = new();
        public List<Course> Courses { get; set; } = new();
    }
}
