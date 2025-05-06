using System.Collections.Generic;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;

namespace TeachCloud.Service
{
    public class GroupService /*: IGroupService*/
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public IEnumerable<Group> GetAllGroups() => _groupRepository.GetAll();

        public Group? GetGroupById(int id) => _groupRepository.GetById(id);

        public Group CreateGroup(Group group)
        {
            _groupRepository.Add(group);
            _groupRepository.Save();
            return group;
        }

        public bool UpdateGroup(int id, Group group)
        {
            var existing = _groupRepository.GetById(id);
            if (existing == null) return false;

            existing.Name = group.Name;

            _groupRepository.Save();
            return true;
        }

        public bool DeleteGroup(int id)
        {
            var group = _groupRepository.GetById(id);
            if (group == null) return false;

            _groupRepository.Delete(group);
            _groupRepository.Save();
            return true;
        }
    }
}