using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;

namespace TeachCloud.Service
{
    public class GroupCourseService : IGroupCourseService
    {
        private readonly IGroupCourseRepository _repository;

        public GroupCourseService(IGroupCourseRepository repository)
        {
            _repository = repository;
        }

        public void Create(GroupCourse groupCourse)
        {
            _repository.Add(groupCourse);
            _repository.Save();
        }
    }
}
