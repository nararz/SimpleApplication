using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Model.Models;
using Task.Web.Models;

namespace Task.Web.Common
{
    public static class Mappers
    {
        #region Group

        public static GroupModel ToGroupModel(this Group group)
        {
            return new GroupModel
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                StoriesCount = group.Stories.Count,
                UserIds = group.Users.Select(u => u.UserId).ToList()
            };
        }

        public static Group ToGroup(this GroupModel groupModel)
        {
            return new Group
            {
                Name = groupModel.Name,
                Description = groupModel.Description
            };
        }

        #endregion

        #region Story

        public static StoryDetailsModel ToStoryDetailsModel(this Story story)
        {
            return new StoryDetailsModel
            {
                Id = story.Id,
                PostedOn = story.PostedOn,
                Title = story.Title,
                Description = story.Description,
                Content = story.Content,
                Groups = story.Groups.Select(g => g.ToGroupModel()).ToList()
            };
        }

        public static StoryModel ToStoryModel(this Story story)
        {
            return new StoryModel
            {
                Id = story.Id,
                Title = story.Title
            };
        }

        public static Story ToStory(this StoryDetailsModel model)
        {
            return new Story()
            {
                Content = model.Content,
                Description = model.Description,
                PostedOn = DateTime.Now,
                Title = model.Title
            };
        }

        #endregion
    }
}