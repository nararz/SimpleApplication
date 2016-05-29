using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Data.Infrastructure;
using Task.Data.Repositories;
using Task.Model.Models;

namespace Task.Service
{
    public interface IGroupService
    {
        IEnumerable<Group> GetGroups();

        IEnumerable<Group> GetGroups(int userId);

        Group GetGroup(int id);

        void UpateGroup(Group group);

        void CreateGroup(Group group);

        void SaveGroup();
    }

    public class GroupService : IGroupService
    {
        #region Fields

        private readonly IGroupRepository groupRepository;
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Ctor

        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            this.groupRepository = groupRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region IGroupService Members

        public IEnumerable<Group> GetGroups()
        {
            var groups = groupRepository.GetAll();
            return groups;
        }

        public IEnumerable<Group> GetGroups(int userId)
        {
            var groups = groupRepository.GetMany(g => g.Users.Any(u => u.UserId == userId));
            return groups;
        }

        public Group GetGroup(int id)
        {
            var group = groupRepository.GetById(id);
            return group;
        }

        public void UpateGroup(Group group)
        {
            groupRepository.Update(group);
        }

        public void CreateGroup(Group group)
        {
            groupRepository.Add(group);
        }

        public void SaveGroup()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
