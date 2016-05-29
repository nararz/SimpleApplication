using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task;
using Task.Web.Controllers;
using Task.Service;
using Moq;
using Task.Model.Models;
using log4net;
using Task.Web.Models;
using MvcContrib.TestHelper;

namespace Task.Tests.Controllers
{
    [TestClass]
    public class GroupControllerTest
    {
        #region Properties

        private  IGroupService _groupService;
        private  IUserService _userService;
        private  ILog _logger;

        private GroupController controller;
        private TestControllerBuilder builder;

        #endregion

        #region Constructors

        public GroupControllerTest()
        {
            Mock<IGroupService> moqGroupService = new Mock<IGroupService>();
            moqGroupService.Setup(s => s.GetGroups()).Returns(new List<Group>());
            moqGroupService.Setup(s => s.GetGroup(It.IsAny<int>())).Returns(new Group());
            moqGroupService.Setup(s => s.CreateGroup(It.IsAny<Group>()));
            moqGroupService.Setup(s => s.UpateGroup(It.IsAny<Group>()));
            moqGroupService.Setup(s => s.SaveGroup());

            Mock<IUserService> moqUserService = new Mock<IUserService>();
            moqUserService.Setup(u => u.GetUser(It.IsAny<int>())).Returns(new User());

            Mock<ILog> moqLog = new Mock<ILog>();

            _groupService = (IGroupService)moqGroupService.Object;
            _userService = (IUserService)moqUserService.Object;
            _logger = (ILog)moqLog.Object;

            controller = new GroupController(_groupService, _userService, _logger);
            builder = new TestControllerBuilder();
            builder.InitializeController(controller);
        }

        #endregion

        #region Additional test attributes

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
        }

        #endregion

        #region Tests

        #region Index Action Tests

        /// <summary>
        ///A test for Index Action Is Not Null
        ///</summary>
        [TestMethod]
        public void Index_Action_IsNull_Test()
        {
            var result = controller.Index();

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for Index Action ViewName
        ///</summary>
        [TestMethod]
        public void Index_Action_ViewName_Test()
        {
            var result = controller.Index() as RedirectToRouteResult;

            if (result.RouteValues["Area"] != null || result.RouteValues["action"].ToString() != "Groups" || result.RouteValues["controller"].ToString() != "Group")
                Assert.Fail("Redirect not working");
        }

        #endregion

        #region Groups Action Tests

        /// <summary>
        ///A test for Groups Action Is Not Null
        ///</summary>
        [TestMethod]
        public void Groups_Action_IsNull_Test()
        {
            var result = controller.Groups();

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for Groups Action model type
        ///</summary>
        [TestMethod]
        public void Groups_Action_Model_Type_Test()
        {
            ViewResult result = controller.Groups() as ViewResult;

            try
            {
                List<GroupModel> groups = (List<GroupModel>)result.ViewData.Model;
            }
            catch
            {
                Assert.Fail("Other motel type");
            }
        }

        #endregion

        #region CreateNewGroup Action Tests

        /// <summary>
        ///A test for CreateNewGroup Action Is Not Null
        ///</summary>
        [TestMethod]
        public void CreateNewGroup_Action_IsNull_Test()
        {
            var result = controller.CreateNewGroup();

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for CreateNewGroup Action Is Not Null(Post)
        ///</summary>
        [TestMethod]
        public void CreateNewGroup_Action_Post_IsNull_Test()
        {
            GroupModel model = new GroupModel();

            var result = controller.CreateNewGroup(model);

            Assert.IsNotNull(result);
        }


        #endregion

        #region LeaveGroup Action Tests

        /// <summary>
        ///A test for LeaveGroup Action Is Not Null
        ///</summary>
        [TestMethod]
        public void LeaveGroup_Action_IsNull_Test()
        {
            int groupId = 1;
            int userId = 1;

            var result = controller.LeaveGroup(groupId , userId);

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for LeaveGroup Action Is Result
        ///</summary>
        [TestMethod]
        public void LeaveGroup_Action_Result_Test()
        {
            int groupId = 1;
            int userId = 1;

            var result = controller.LeaveGroup(groupId, userId) as JsonResult;

            Assert.AreEqual("true", result.Data.ToString());
        }

        /// <summary>
        ///A test for LeaveGroup Action Is Excaption
        ///</summary>
        [TestMethod]
        public void LeaveGroup_Action_Excaption_Test()
        {
            Mock<IGroupService> moqGroupService = new Mock<IGroupService>();
            moqGroupService.Setup(x => x.GetGroup(It.IsAny<int>())).Returns(new Group());
            moqGroupService.Setup(x => x.UpateGroup(It.IsAny<Group>()));
            moqGroupService.Setup(x => x.SaveGroup()).Throws(new Exception());

            Mock<IUserService> moqUserService = new Mock<IUserService>();
            moqUserService.Setup(x => x.GetUser(It.IsAny<int>())).Returns(new User());


            _groupService = (IGroupService)moqGroupService.Object;
            _userService = (IUserService)moqUserService.Object;

            controller = new GroupController(_groupService, _userService, _logger);
            builder = new TestControllerBuilder();
            builder.InitializeController(controller);

            int groupId = 1;
            int userId = 1;

            var result = controller.LeaveGroup(groupId, userId) as JsonResult;

            Assert.AreEqual("false", result.Data.ToString());
        }

        #endregion

        #region JoinTheGroup Action Tests

        /// <summary>
        ///A test for JoinTheGroup Action Is Not Null
        ///</summary>
        [TestMethod]
        public void JoinTheGroup_Action_IsNull_Test()
        {
            int groupId = 1;
            int userId = 1;

            var result = controller.JoinTheGroup(groupId, userId);

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for JoinTheGroup Action Is Result
        ///</summary>
        [TestMethod]
        public void JoinTheGroup_Action_Result_Test()
        {
            int groupId = 1;
            int userId = 1;

            var result = controller.JoinTheGroup(groupId, userId) as JsonResult;

            Assert.AreEqual("true", result.Data.ToString());
        }

        /// <summary>
        ///A test for JoinTheGroup Action Is Excaption
        ///</summary>
        [TestMethod]
        public void JoinTheGroup_Action_Excaption_Test()
        {
            Mock<IGroupService> moqGroupService = new Mock<IGroupService>();
            moqGroupService.Setup(x => x.GetGroup(It.IsAny<int>())).Returns(new Group());
            moqGroupService.Setup(x => x.UpateGroup(It.IsAny<Group>()));
            moqGroupService.Setup(x => x.SaveGroup()).Throws(new Exception());

            Mock<IUserService> moqUserService = new Mock<IUserService>();
            moqUserService.Setup(x => x.GetUser(It.IsAny<int>())).Returns(new User());


            _groupService = (IGroupService)moqGroupService.Object;
            _userService = (IUserService)moqUserService.Object;

            controller = new GroupController(_groupService, _userService, _logger);
            builder = new TestControllerBuilder();
            builder.InitializeController(controller);

            int groupId = 1;
            int userId = 1;

            var result = controller.JoinTheGroup(groupId, userId) as JsonResult;

            Assert.AreEqual("false", result.Data.ToString());
        }

        #endregion

        #endregion
    }
}
