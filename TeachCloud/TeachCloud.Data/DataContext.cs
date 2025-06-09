using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // הכנסת נתונים התחלתיים (seeding)
        //    modelBuilder.Entity<Admin>().HasData(new Admin
        //    {
        //        Id = 1,
        //        FullName = "שרה כהן",
        //        Email = "sara@example.com",
        //        PasswordHash = "123456"
        //    });

        //    modelBuilder.Entity<Course>().HasData(
        //        new Course { Id = 1, Name = "מתמטיקה" },
        //        new Course
        //        {
        //            Id = 2,
        //            Name = "היסטוריה"
        //        }
        //    );
        //}
    }
}

                