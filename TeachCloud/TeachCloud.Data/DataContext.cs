//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using TeachCloud.Core.Entities;

//namespace TeachCloud.Data
//{
//    //public class DataContext : DbContext
//    //{
//    //    public DbSet<Admin> Admins { get; set; }
//    //    public DbSet<Course> Courses { get; set; }
//    //    public DbSet<Core.Entities.File> Files { get; set; }
//    //    public DbSet<Group> Groups { get; set; }
//    //    public DbSet<Institution> Institutions { get; set; }
//    //    public DbSet<Lesson> Lessons { get; set; }
//    //    public DbSet<Student> Students { get; set; }
//    //    public DbSet<Teacher> Teachers { get; set; }

//    //    public DataContext(DbContextOptions<DataContext> options) : base(options) { }


//    //}

//    public class DataContext : DbContext
//    {
//        public DbSet<Admin> Admins { get; set; }
//        public DbSet<Course> Courses { get; set; }
//        public DbSet<Core.Entities.File> Files { get; set; }
//        public DbSet<Group> Groups { get; set; }
//        public DbSet<Institution> Institutions { get; set; }
//        public DbSet<Lesson> Lessons { get; set; }
//        public DbSet<Student> Students { get; set; }
//        public DbSet<Teacher> Teachers { get; set; }
//        //public DbSet<GroupCourse> GroupCourses { get; set; }


//        // 👇 חשוב: אל תשכחי להוסיף גם את זה
//        public DbSet<GroupCourse> GroupCourses { get; set; }

//        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // 🔁 הגדרה של קשר רבים-לרבים בין Group ל־Course דרך GroupCourse
//            modelBuilder.Entity<GroupCourse>()
//                .HasKey(gc => new { gc.GroupId, gc.CourseId });

//            modelBuilder.Entity<GroupCourse>()
//                .HasOne(gc => gc.Group)
//                .WithMany(g => g.GroupCourses)
//                .HasForeignKey(gc => gc.GroupId);

//            modelBuilder.Entity<GroupCourse>()
//                .HasOne(gc => gc.Course)
//                .WithMany(c => c.GroupCourses)
//                .HasForeignKey(gc => gc.CourseId);
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using TeachCloud.Core.Entities;

namespace TeachCloud.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Core.Entities.File> Files { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<GroupCourse> GroupCourses { get; set; }

        // 👇 נוסיף גם את זה:
        public DbSet<TeacherGroup> TeacherGroups { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔁 קשר רבים-לרבים בין Group ל־Course
            modelBuilder.Entity<GroupCourse>()
                .HasKey(gc => new { gc.GroupId, gc.CourseId });

            modelBuilder.Entity<GroupCourse>()
                .HasOne(gc => gc.Group)
                .WithMany(g => g.GroupCourses)
                .HasForeignKey(gc => gc.GroupId);

            modelBuilder.Entity<GroupCourse>()
                .HasOne(gc => gc.Course)
                .WithMany(c => c.GroupCourses)
                .HasForeignKey(gc => gc.CourseId);

            // 🔁 קשר רבים-לרבים בין Group ל־Teacher
            modelBuilder.Entity<TeacherGroup>()
                .HasKey(tg => new { tg.TeacherId, tg.GroupId });

            modelBuilder.Entity<TeacherGroup>()
                .HasOne(tg => tg.Teacher)
                .WithMany(t => t.TeacherGroups)
                .HasForeignKey(tg => tg.TeacherId);

            modelBuilder.Entity<TeacherGroup>()
                .HasOne(tg => tg.Group)
                .WithMany(g => g.TeacherGroups)
                .HasForeignKey(tg => tg.GroupId);
        }
    }
}
