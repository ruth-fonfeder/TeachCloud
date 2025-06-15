namespace TeachCloud.Core.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public List<CourseSimpleDto> Courses { get; set; } = new();

        public class CourseSimpleDto
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }
    }
}
