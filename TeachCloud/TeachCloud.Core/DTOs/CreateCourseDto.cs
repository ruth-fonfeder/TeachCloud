using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.DTOs
{
    public class CreateCourseDto
    {
        public string Name { get; set; } = string.Empty;
        public List<GroupSimpleDto> StudyGroups { get; set; } = new();
    }
}
