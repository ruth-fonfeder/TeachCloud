using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // קשרים
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public List<Student> Students { get; set; } = new();
        public int? AdminId { get; set; }  // 👈 זה מאפשר ערך null

    }


}
