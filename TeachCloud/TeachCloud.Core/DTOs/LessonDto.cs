using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TeachCloud.Core.DTOs
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int StudyGroupId { get; set; }
        public string StudyGroupName { get; set; } = string.Empty;
        public List<FileDto> Files { get; set; } = new();

        public class FileDto
        {
            public int Id { get; set; }
            public string FileName { get; set; } = string.Empty;
            public string FilePath { get; set; } = string.Empty;
        }
    }


}
