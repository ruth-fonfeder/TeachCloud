using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // קשרים
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        public List<Group> StudyGroups { get; set; } = new();
    }
}
