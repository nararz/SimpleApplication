using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Model.Models;
using Task.Service;
using Task.Web.Models;
using WebMatrix.WebData;
using Task.Web.Common;

namespace Task.Web.Controllers
{
    [Authorize]
    public class StoryController : Controller
    {
        #region Properties

        private readonly IStoryService _storyService;
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;
        private readonly ILog _logger;

        #endregion

        #region Constructors

        public StoryController(IStoryService storyService, IGroupService groupService, IUserService userService, ILog logger)
        {
            this._storyService = storyService;
            this._groupService = groupService;
            this._userService = userService;
            this._logger = logger;
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("MyStories", "Story");
        }

        [HttpGet]
        public ActionResult MyStories()
        {
            List<StoryModel> model = new List<StoryModel>();
            try
            {
                var stories = _storyService.GetStories(WebSecurity.CurrentUserId);
                model = stories.Select(s => s.ToStoryModel()).ToList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult GroupStories(int id)
        {
            List<StoryModel> model = new List<StoryModel>();
            try
            {
                var stories = _storyService.GetGroupStories(id);
                model = stories.Select(s => s.ToStoryModel()).ToList();

                ViewBag.GroupName = _groupService.GetGroup(id).Name;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Story(int id)
        {
            StoryDetailsModel model = new StoryDetailsModel();
            try
            {
                var story = _storyService.GetStory(id);
                model = story.ToStoryDetailsModel();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditStory(int id)
        {
            StoryDetailsModel model = new StoryDetailsModel();
            try
            {
                var story = _storyService.GetStory(id);
                model = story.ToStoryDetailsModel();

                ViewBag.Groups = _groupService.GetGroups(WebSecurity.CurrentUserId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditStory(StoryDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Story story = _storyService.GetStory(model.Id);

                    story.Content = model.Content;
                    story.Description = model.Description;
                    story.PostedOn = DateTime.Now;
                    story.Title = model.Title;

                    User user = _userService.GetUser(WebSecurity.CurrentUserId);
                    story.User = user;

                    story.Groups.Clear();
                    if (model.Groups.Count > 0)
                    {
                        foreach (GroupModel groupModel in model.Groups)
                        {
                            if (groupModel.Id != 0)
                            {
                                Group group = _groupService.GetGroup(groupModel.Id);
                                story.Groups.Add(group);
                            }
                        }
                    }
                    _storyService.UpdateStory(story);
                    _storyService.SaveStory();

                    return RedirectToAction("MyStories", "Story");
                }
                catch (Exception ex)
                {
                    _logger.Error("Cannot edit story", ex);
                }
            }
            ViewBag.Groups = null;
            try
            {
                ViewBag.Groups = _groupService.GetGroups(WebSecurity.CurrentUserId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateNewStory()
        {
            ViewBag.Groups = null;
            try
            {
                ViewBag.Groups = _groupService.GetGroups(WebSecurity.CurrentUserId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewStory(StoryDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Story newStory = model.ToStory();
                    User user = _userService.GetUser(WebSecurity.CurrentUserId);
                    newStory.User = user;
                    if (model.Groups.Count > 0)
                    {
                        foreach (var groupModel in model.Groups)
                        {
                            if (groupModel.Id != 0)
                            {
                                Group group = _groupService.GetGroup(groupModel.Id);
                                newStory.Groups.Add(group);
                            }
                        }
                    }
                    _storyService.CreateStory(newStory);
                    _storyService.SaveStory();

                    return RedirectToAction("MyStories", "Story");
                }
                catch (Exception ex)
                {
                    _logger.Error("Cannot create new story", ex);
                }
            }
            ViewBag.Groups = null;
            try
            {
                ViewBag.Groups = _groupService.GetGroups(WebSecurity.CurrentUserId);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return View(model);
        }

        #endregion
    }
}