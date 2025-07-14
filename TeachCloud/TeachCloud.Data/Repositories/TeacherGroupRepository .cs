using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;

namespace TeachCloud.Data.Repositories
{
    public class TeacherGroupRepository : ITeacherGroupRepository
    {
        private readonly DataContext _context;

        public TeacherGroupRepository(DataContext context)
        {
            _context = context;
        }

        public bool Exists(int teacherId, int groupId)
        {
            return _context.TeacherGroups.Any(tg => tg.TeacherId == teacherId && tg.GroupId == groupId);
        }

        public void Add(TeacherGroup teacherGroup)
        {
            _context.TeacherGroups.Add(teacherGroup);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
