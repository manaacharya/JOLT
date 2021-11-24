using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using ContosoCrafts.WebSite.Pages.PollsPages;

namespace UnitTests.Pages.Polls
{
    /// <summary>
    /// Read Poll Page Unit Test
    /// </summary>
    class ReadPollPage
    {
        #region TestSetup

        // CreatePollPage Model static field/attribute
        public static ReadPollPageModel PageModel;

        /// <summary>
        /// Test Initialization for ProfilePage
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // logging attribute created
            var MockLoggerDirect = Mock.Of<ILogger<ReadPollPageModel>>();

            // Profile Model instance created with logging attribute passed in constructor
            PageModel = new ReadPollPageModel(MockLoggerDirect,  TestHelper.PollService,TestHelper.UserService)
            {
                // Set the Page Context
                PageContext = TestHelper.PageContext

            };
        }

        #endregion TestSetup


        #region OnGet

        /// <summary>
        /// Unit Test for OnGet on Valid ID
        /// </summary>
        [Test]
        public void OnGet_ValidId_Should_Return_Page()
        {
            // Arrange
            // valid id
            var validID = 1;

            // Act
            var pageresult = PageModel.OnGet(validID) as RedirectToPageResult;

            // Reset

            // Assert

            // Assert Page Redirection
            Assert.AreEqual(true, pageresult.PageName.Contains("ReadPollPage"));
        }

        /// <summary>
        /// Unit Test for OnGet on Invalid ID
        /// </summary>
        [Test]
        public void OnGet_InValidId_Should_Return_Page()
        {
            // Arrange
            // invalid ID
            var invalidID = -21;

            // Act
            var pageresult = PageModel.OnGet(invalidID) as RedirectToPageResult;

            // Reset

            // Assert

            // Assert Page Redirection
            Assert.AreEqual(true, pageresult.PageName.Contains("Index"));
        }


        #endregion OnGet

    }
}
