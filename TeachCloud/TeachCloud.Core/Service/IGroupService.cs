using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Service
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAllGroups();
        Group? GetGroupById(int id);
        Group CreateGroup(Group group);
        bool UpdateGroup(int id, Group group);
        bool DeleteGroup(int id);
    }
}