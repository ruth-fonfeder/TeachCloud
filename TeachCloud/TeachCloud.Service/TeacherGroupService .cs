using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Service;
using TeachCloud.Data;

namespace TeachCloud.Service
{
    // בתיקיה Services
    //public class TeacherGroupService : ITeacherGroupService
    //{
    //    private readonly DataContext _context;

    //    public TeacherGroupService(DataContext context)
    //    {
    //        _context = context;
    //    }

    //    public void Add(TeacherGroup teacherGroup)
    //    {
    //        _context.TeacherGroups.Add(teacherGroup);
    //        _context.SaveChanges();
    //    }
    //}

    public class TeacherGroupService : ITeacherGroupService
    {
        private readonly DataContext _context;

        public TeacherGroupService(DataContext context)
        {
            _context = context;
        }

        public void Add(TeacherGroup teacherGroup)
        {
            bool exists = _context.TeacherGroups
                .Any(tg => tg.TeacherId == teacherGroup.TeacherId && tg.GroupId == teacherGroup.GroupId);

            if (!exists)
            {
                _context.TeacherGroups.Add(teacherGroup);
                _context.SaveChanges();
            }
            // אם את רוצה, אפשר גם לזרוק שגיאה אם כבר קיים
            // else throw new InvalidOperationException("קשר כבר קיים");
        }
    }

}
