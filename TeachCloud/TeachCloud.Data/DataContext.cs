using System;
using System.Collections.Generic;
using TeachCloud.Core.Entities;

namespace TeachCloud.Data
{
    public class DataContext
    {
        public List<Admin> Admins { get; set; }
        public List<Course> Courses { get; set; }
        public List<Core.Entities.File> Files { get; set; }
        public List<Group> Groups { get; set; }
        public List<Institution> Institutions { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }

        public DataContext()
        {
            // אתחול כל הרשימות
            Admins = new List<Admin>();
            Courses = new List<Course>();
            Files = new List<Core.Entities.File>();
            Groups = new List<Group>();
            Institutions = new List<Institution>();
            Lessons = new List<Lesson>();
            Students = new List<Student>();
            Teachers = new List<Teacher>();

            // עכשיו אפשר להכניס מידע
            Admins.Add(new Admin
            {
                FullName = "שרה כהן",
                Email = "sara@example.com",
                PasswordHash = "123456",
                Teachers = new List<Teacher>(),
                Groups = new List<Group>()
            });

            Courses.AddRange(new[]
            {
                new Course { Id = 1, Name = "מתמטיקה" },
                new Course { Id = 2, Name = "היסטוריה" }
            });
        }
    }

}


