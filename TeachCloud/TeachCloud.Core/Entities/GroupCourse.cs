using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Entities
{
    public class GroupCourse
    {
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }

}
