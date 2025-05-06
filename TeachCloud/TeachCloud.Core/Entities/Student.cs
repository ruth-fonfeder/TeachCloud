using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Entities
{
    public class Student : User
    {

        public Student() : base(UserRole.Student) { }

        public List<Group> StudyGroups { get; set; } = new();
    }
}
