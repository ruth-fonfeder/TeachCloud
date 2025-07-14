using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachCloud.Core.Entities
{
    //public class Group
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; } = string.Empty;

    //    // קשרים
    //    public int CourseId { get; set; }
    //    public Course Course { get; set; } = null!;

    //    public List<Student> Students { get; set; } = new();
    //    public int? AdminId { get; set; }  // 👈 זה מאפשר ערך null

    //}

    //public class Group
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; } = string.Empty;

    //    public List<GroupCourse> GroupCourses { get; set; } = new();

    //    public List<Student> Students { get; set; } = new();
    //    public int? AdminId { get; set; }
    //}


    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // ✅ קשר לרשימת קורסים (רבים-לרבים)
        public List<GroupCourse> GroupCourses { get; set; } = new();

        // ✅ קשר לסטודנטים
        public List<Student> Students { get; set; } = new();

        // ✅ קשר למורים דרך טבלת קשר TeacherGroup
        public List<TeacherGroup> TeacherGroups { get; set; } = new();

        // ✅ מזהה מנהל (אופציונלי)
        public int? AdminId { get; set; }
    }

}
