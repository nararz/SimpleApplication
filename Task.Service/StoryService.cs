using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Data.Infrastructure;
using Task.Data.Repositories;
using Task.Model.Models;

namespace Task.Service
{
    public interface IStoryService
    {
        IEnumerable<Story> GetStories();

        IEnumerable<Story> GetStories(int userId);

        IEnumerable<Story> GetGroupStories(int groupId);

        Story GetStory(int id);

        void CreateStory(Story story);

        void UpdateStory(Story story);

        void SaveStory();
    }

    public class StoryService : IStoryService
    {
        #region Fields

        private readonly IStoryRepository stroyRepository;
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Ctor

        public StoryService(IStoryRepository stroyRepository, IUnitOfWork unitOfWork)
        {
            this.stroyRepository = stroyRepository;
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region IStoryService Members

        public IEnumerable<Story> GetStories()
        {
            var stories = stroyRepository.GetAll();
            return stories;
        }

        public IEnumerable<Story> GetStories(int userId)
        {
            var stories = stroyRepository.GetMany(x => x.User.UserId == userId);
            return stories;
        }

        public IEnumerable<Story> GetGroupStories(int groupId)
        {
            var stories = stroyRepository.GetMany(x => x.Groups.Any(g => g.Id == groupId));
            return stories;
        }

        public Story GetStory(int id)
        {
            var story = stroyRepository.GetById(id);
            return story;
        }

        public void CreateStory(Story story)
        {
            stroyRepository.Add(story);
        }

        public void UpdateStory(Story story)
        {
            stroyRepository.Update(story);
        }

        public void SaveStory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
