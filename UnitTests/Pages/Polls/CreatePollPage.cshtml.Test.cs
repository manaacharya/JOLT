using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Pages.PollsPages;

namespace UnitTests.Pages.Polls
{
    class CreatePollPage
    {
        #region TestSetup

        // CreatePollPage Model static field/attribute
        public static CreatePollPageModel PageModel;

        /// <summary>
        /// Test Initialization for ProfilePage
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // logging attribute created
            var MockLoggerDirect = Mock.Of<ILogger<CreatePollPageModel>>();

            // Profile Model instance created with logging attribute passed in constructor
            PageModel = new CreatePollPageModel(MockLoggerDirect, TestHelper.UserService, TestHelper.PollService)
            {
                // Set the Page Context
                PageContext = TestHelper.PageContext
            };
        }

        #endregion TestSetup

        #region OnGet

        [Test]
        public void OnGet_Valid_Should_Generate_Welcome_Message()
        {
            // Arrange
            TestHelper.UserService.CreateCookie("nameCookie", "PersonTest");

            // Act

            PageModel.OnGet();

            // Reset

            // Assert

            // check model state is valid 
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            // check whether messag was created
            Assert.AreEqual(true, PageModel.Message.Equals($"Welcome PersonTest:  Create Your Amazing Poll"));
        }
        #endregion OnGet

        #region OnPost
        #endregion OnPost

    }
}
