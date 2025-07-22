using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;

namespace TeachCloud.Data.Repositories
{
    public class GroupCourseRepository : IGroupCourseRepository
    {
        private readonly DataContext _context;

        public GroupCourseRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(GroupCourse groupCourse)
        {
            _context.GroupCourses.Add(groupCourse);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void DeleteRange(IEnumerable<GroupCourse> groupCourses)
        {
            _context.GroupCourses.RemoveRange(groupCourses);
        }
        public IEnumerable<GroupCourse> GetAll()
        {
            return _context.GroupCourses
                .Include(gc => gc.Group)
                .Include(gc => gc.Course)
                .ToList();
        }
        public IEnumerable<GroupDto> GetGroupsByCourseId(int courseId)
        {
            var groups = _context.GroupCourses
                .Where(gc => gc.CourseId == courseId)
                .Select(gc => new GroupDto
                {
                    Id = gc.Group.Id,
                    Name = gc.Group.Name
                })
                .ToList();

            return groups;
        }
    }
}
