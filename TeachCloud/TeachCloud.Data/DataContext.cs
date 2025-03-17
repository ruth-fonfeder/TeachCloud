using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;
namespace TeachCloud.Data
{
    public class DataContext
    {
        public List<Admin> Admins { get; set; }
        public List<Course> Courses { get; set; }
        public List<Core.Entities.File> Files { get; set; }
        public List<Core.Entities.Group> Groups { get; set; }
        public List<Institution> Institutions { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }

        public DataContext()
        {
            Admins = new List<Admin>();
            Courses = new List<Course>();
            Files = new List<Core.Entities.File>();
            Groups = new List<Core.Entities.Group>();
            Institutions = new List<Institution>();
            Lessons = new List<Lesson>();
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }
    }
}
