using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;

        // קשרים
        public int StudyGroupId { get; set; }
        public Group StudyGroup { get; set; } = null!;

        public List<File> Files { get; set; } = new();
    }
}
