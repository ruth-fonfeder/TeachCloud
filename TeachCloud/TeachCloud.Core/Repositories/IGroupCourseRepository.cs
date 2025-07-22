using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Repositories
{
    public interface IGroupCourseRepository
    {
        IEnumerable<GroupDto> GetGroupsByCourseId(int courseId);
        void Add(GroupCourse groupCourse);
        void Save();
        void DeleteRange(IEnumerable<GroupCourse> groupCourses);
        public IEnumerable<GroupCourse> GetAll();

    }
}
