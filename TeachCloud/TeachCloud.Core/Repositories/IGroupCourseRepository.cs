using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Repositories
{
    public interface IGroupCourseRepository
    {
        void Add(GroupCourse groupCourse);
        void Save();
    }
}
