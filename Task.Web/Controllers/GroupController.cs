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
    public class GroupController : Controller
    {
        #region Properties

        private readonly IGroupService _groupService;
        private readonly IUserService _userService;
        private readonly ILog _logger;

        #endregion

        #region Constructors

        public GroupController(IGroupService groupService, IUserService userService, ILog logger)
        {
            this._groupService = groupService;
            this._userService = userService;
            this._logger = logger;
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Groups", "Group");
        }

        [HttpGet]
        public ActionResult Groups()
        {
            List<GroupModel> model = new List<GroupModel>();
            try
            {
                var groups = _groupService.GetGroups();
                model = groups.Select(g => g.ToGroupModel()).ToList();
                ViewBag.CurrentUserId = WebSecurity.CurrentUserId;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateNewGroup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewGroup(GroupModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Group newGroup = model.ToGroup();
                    User user = _userService.GetUser(WebSecurity.CurrentUserId);
                    newGroup.Users.Add(user);

                    _groupService.CreateGroup(newGroup);
                    _groupService.SaveGroup();


                    return RedirectToAction("Index", "Group");
                }
                catch (Exception ex)
                {
                    _logger.Error("Cannot create new group", ex);
                }
            }
            return View(model);
        }

        [HttpGet]
        public JsonResult LeaveGroup(int GroupId, int UserId)
        {
            try
            {
                var group = _groupService.GetGroup(GroupId);
                group.Users.Remove(group.Users.FirstOrDefault(g => g.UserId == UserId));
                _groupService.UpateGroup(group);
                _groupService.SaveGroup();

                return Json("true", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.Error("Cannot leave group", ex);

                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult JoinTheGroup(int GroupId, int UserId)
        {
            try
            {
                var group = _groupService.GetGroup(GroupId);
                var user = _userService.GetUser(UserId);
                group.Users.Add(user);
                _groupService.UpateGroup(group);
                _groupService.SaveGroup();

                return Json("true", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.Error("Cannot join to group", ex);

                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}