using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task;
using Task.Web.Controllers;
using MvcContrib.TestHelper;

namespace Task.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        #region Properties

        private HomeController controller;
        private TestControllerBuilder builder;

        #endregion

        #region Constructors

        public HomeControllerTest()
        {
            controller = new HomeController();
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

        #region "Tests"

        #region "Index Action Tests"

        /// <summary>
        ///A test for Index Action Is Not Null
        ///</summary>
        [TestMethod]
        public void Index_Action_IsNull_Test()
        {
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        /// <summary>
        ///A test for Index Action ViewName
        ///</summary>
        [TestMethod]
        public void Index_Action_ViewName_Test()
        {
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);
        }

        #endregion

        #endregion
    }
}
