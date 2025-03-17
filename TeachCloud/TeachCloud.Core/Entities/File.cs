using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;

        // קשרים
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
    }
}
