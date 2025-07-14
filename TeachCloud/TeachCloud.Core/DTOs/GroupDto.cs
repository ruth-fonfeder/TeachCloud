using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TeachCloud.Core.DTOs.TeacherDto;

namespace TeachCloud.Core.DTOs
{
    //public class GroupDto
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; } = string.Empty;
    //    public int CourseId { get; set; }
    //    public string CourseName { get; set; } = string.Empty;
    //}


    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // במקום CourseId יחיד - רשימת קורסים פשוטים
        public List<CourseSimpleDto> Courses { get; set; } = new();

    }
}
