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
using MvcContrib.TestHelper;
using Task.Web.Models;

namespace Task.Tests.Controllers
{
    [TestClass]
    public class StoryControllerTest
    {
        #region Properties

        private IStoryService _storyService;
        private IGroupService _groupService;
        private IUserService _userService;
        private ILog _logger;

        private StoryController controller;
        private TestControllerBuilder builder;

        #endregion

        #region Constructors

        public StoryControllerTest()
        {
            Mock<IStoryService> moqStoryService = new Mock<IStoryService>();
            moqStoryService.Setup(s => s.GetStories()).Returns(new List<Story>());
            moqStoryService.Setup(s => s.GetStories(It.IsAny<int>())).Returns(new List<Story>());
            moqStoryService.Setup(s => s.GetStory(It.IsAny<int>())).Returns(new Story());
            moqStoryService.Setup(s => s.UpdateStory(It.IsAny<Story>()));
            moqStoryService.Setup(s => s.CreateStory(It.IsAny<Story>()));
            moqStoryService.Setup(s => s.SaveStory());

            Mock<IGroupService> moqGroupService = new Mock<IGroupService>();
            moqGroupService.Setup(s => s.GetGroups(It.IsAny<int>())).Returns(new List<Group>());
            moqGroupService.Setup(s => s.GetGroup(It.IsAny<int>())).Returns(new Group());

            Mock<IUserService> moqUserService = new Mock<IUserService>();
            moqUserService.Setup(u => u.GetUser(It.IsAny<int>())).Returns(new User());

            Mock<ILog> moqLog = new Mock<ILog>();


            _storyService = (IStoryService)moqStoryService.Object;
            _groupService = (IGroupService)moqGroupService.Object;
            _userService = (IUserService)moqUserService.Object;
            _logger = (ILog)moqLog.Object;

            controller = new StoryController(_storyService, _groupService, _userService, _logger);
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

        #region Index Action Tests"

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
        ///A test for Index Action RedirectToAction
        ///</summary>
        [TestMethod]
        public void Index_Action_ViewName_Test()
        {
            var result = controller.Index() as RedirectToRouteResult;

            if (result.RouteValues["Area"] != null || result.RouteValues["action"].ToString() != "MyStories" || result.RouteValues["controller"].ToString() != "Story")
                Assert.Fail("Redirect not working");
        }

        #endregion

        #region MyStories Action Tests

        /// <summary>
        ///A test for MyStories Action Is Not Null
        ///</summary>
        [TestMethod]
        public void MyStories_Action_IsNull_Test()
        {
            var result = controller.MyStories();

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for MyStories Action model type
        ///</summary>
        [TestMethod]
        public void MyStories_Action_Model_Type_Test()
        {
            ViewResult result = controller.MyStories() as ViewResult;

            try
            {
                List<StoryModel> stories = (List<StoryModel>)result.ViewData.Model;
            }
            catch
            {
                Assert.Fail("Other motel type");
            }
        }

        #endregion

        #region GroupStories Action Tests

        /// <summary>
        ///A test for GroupStories Action Is Not Null
        ///</summary>
        [TestMethod]
        public void GroupStories_Action_IsNull_Test()
        {
            int groupId = 1;
            var result = controller.GroupStories(groupId);

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for GroupStories Action model type
        ///</summary>
        [TestMethod]
        public void GroupStories_Action_Model_Type_Test()
        {
            int groupId = 1;
            ViewResult result = controller.GroupStories(groupId) as ViewResult;

            try
            {
                List<StoryModel> stories = (List<StoryModel>)result.ViewData.Model;
            }
            catch
            {
                Assert.Fail("Other motel type");
            }
        }

        #endregion

        #region Story Action Tests

        /// <summary>
        ///A test for Story Action Is Not Null
        ///</summary>
        [TestMethod]
        public void Story_Action_IsNull_Test()
        {
            int storyId = 1;
            var result = controller.GroupStories(storyId);

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for Story Action model type
        ///</summary>
        [TestMethod]
        public void Story_Action_Model_Type_Test()
        {
            int storyId = 1;
            ViewResult result = controller.Story(storyId) as ViewResult;

            try
            {
                StoryDetailsModel story = (StoryDetailsModel)result.ViewData.Model;
            }
            catch
            {
                Assert.Fail("Other motel type");
            }
        }

        #endregion

        #region EditStory Action Tests

        /// <summary>
        ///A test for EditStory Action Is Not Null
        ///</summary>
        [TestMethod]
        public void EditStory_Action_IsNull_Test()
        {
            int storyId = 1;
            var result = controller.EditStory(storyId);

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for EditStory Action model type
        ///</summary>
        [TestMethod]
        public void EditStory_Action_Model_Type_Test()
        {
            int storyId = 1;
            ViewResult result = controller.EditStory(storyId) as ViewResult;

            try
            {
                StoryDetailsModel stories = (StoryDetailsModel)result.ViewData.Model;
            }
            catch
            {
                Assert.Fail("Other motel type");
            }
        }

        /// <summary>
        ///A test for EditStory Action Is Not Null(Post)
        ///</summary>
        [TestMethod]
        public void EditStory_Action_Post_IsNull_Test()
        {
            StoryDetailsModel model = new StoryDetailsModel();
            var result = controller.EditStory(model);

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for EditStory Action Is Throw Excaption (Post)
        ///</summary>
        [TestMethod]
        public void EditStory_Action_Post_Model_Type_Test()
        {
            StoryDetailsModel model = new StoryDetailsModel();
            ViewResult result = controller.EditStory(model) as ViewResult;

            try
            {
                StoryDetailsModel stories = (StoryDetailsModel)result.ViewData.Model;
            }
            catch
            {
                Assert.Fail("Other motel type");
            }
        }

        #endregion

        #region CreateNewStory Action Tests

        /// <summary>
        ///A test for CreateNewStory Action Is Not Null
        ///</summary>
        [TestMethod]
        public void CreateNewStory_Action_IsNull_Test()
        {
            var result = controller.CreateNewStory();

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for CreateNewStory Action model type
        ///</summary>
        [TestMethod]
        public void CreateNewStory_Action_Model_Type_Test()
        {
            ViewResult result = controller.CreateNewStory() as ViewResult;

            try
            {
                StoryModel stories = (StoryModel)result.ViewData.Model;
            }
            catch
            {
                Assert.Fail("Other motel type");
            }
        }

        /// <summary>
        ///A test for CreateNewStory Action Is Not Null(Post)
        ///</summary>
        [TestMethod]
        public void CreateNewStory_Action_Post_IsNull_Test()
        {
            StoryDetailsModel model = new StoryDetailsModel();
            var result = controller.CreateNewStory(model);

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for CreateNewStory Action Is Throw Excaption (Post)
        ///</summary>
        [TestMethod]
        public void CreateNewStory_Action_Post_Model_Type_Test()
        {
            StoryDetailsModel model = new StoryDetailsModel();
            ViewResult result = controller.CreateNewStory(model) as ViewResult;

            try
            {
                StoryDetailsModel stories = (StoryDetailsModel)result.ViewData.Model;
            }
            catch
            {
                Assert.Fail("Other motel type");
            }
        }

        #endregion

        #endregion
    }
}
