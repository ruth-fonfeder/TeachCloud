﻿//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using TeachCloud.Core.Entities;
//using TeachCloud.Core.Repositories;

//namespace TeachCloud.Data.Repositories
//{
//    public class GroupRepository : IGroupRepository
//    {
//        private readonly DataContext _context;

//        public GroupRepository(DataContext context)
//        {
//            _context = context;
//        }

//        //public IEnumerable<Group> GetAll() => _context.Groups.ToList();
//        public IEnumerable<Group> GetAll() =>
//    _context.Groups
//        .Include(g => g.Course) // ✅ כדי שגם בקריאה מרובה ייטען שם הקורס
//        .ToList();

//        //public Group? GetById(int id) => _context.Groups.FirstOrDefault(g => g.Id == id);

//        public Group? GetById(int id)
//        {
//            return _context.Groups
//                .Include(g => g.Course) // 👈 חובה כדי שיטעין גם את הקורס
//                .FirstOrDefault(g => g.Id == id);
//        }
//        public void Add(Group group) => _context.Groups.Add(group);
//        public void Delete(Group group) => _context.Groups.Remove(group);
//        public void Save() => _context.SaveChanges();
//    }
//}




using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;

namespace TeachCloud.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;

        public GroupRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Group> GetAll() =>
            _context.Groups
                .Include(g => g.GroupCourses)
                    .ThenInclude(gc => gc.Course)
                .ToList();

        public Group? GetById(int id)
        {
            return _context.Groups
                .Include(g => g.GroupCourses)
                    .ThenInclude(gc => gc.Course)
                .FirstOrDefault(g => g.Id == id);
        }

        public void Add(Group group) => _context.Groups.Add(group);
        public void Delete(Group group) => _context.Groups.Remove(group);
        public void Save() => _context.SaveChanges();
    }
}
