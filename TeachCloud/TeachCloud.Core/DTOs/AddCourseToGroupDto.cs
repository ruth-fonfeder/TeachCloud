using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.DTOs
{
    public class AddCourseToGroupDto
    {
        public int GroupId { get; set; }
        public int CourseId { get; set; }
    }
}
