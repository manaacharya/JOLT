using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Pages;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace UnitTests.Pages.Polls
{   
    /// <summary>
    /// PollPageTest tests all code in PollsPage.cshtml
    /// </summary>
    class PollsPageTest
    {
        #region TestSetup

        //create PollsPagemodel object 
        public static PollsPageModel PageModel;

        /// <summary>
        /// create test logger and PageContect object for testing 
        /// </summary>
        [SetUp] 
        public void TestInitialize()
        {
            //logger object
            var MockLoggerDirect = Mock.Of<ILogger<PollsPageModel>>();

            //assign logger to PageModel 
            PageModel = new PollsPageModel(MockLoggerDirect, TestHelper.PollService)
            {
                //create PageContext object 
                PageContext = TestHelper.PageContext
            };
        }

        #endregion TestSetup


        #region OnGet

        /// <summary>
        /// Test OnGet(), check if the result is valid
        /// </summary>
        [Test]
        public void OnGet_Returns_Valid_PollsList()
        {
            // Arrange

            //Act
            PageModel.OnGet();

            // Reset

            // Assert

            // check if the page model is valid
            Assert.AreEqual(true, PageModel.ModelState.IsValid);

            // check if there is any polls fetch from the PollService
            Assert.AreEqual(true, PageModel.Polls.Any());
        }

        #endregion OnGet

        
        #region OnPost

        /// <summary>
        /// Test OnPost(), check if the result is valid
        /// </summary>
        [Test]
        public void OnPost_Valid()
        {
            //  Arrange 

            //  Act 

            // Fetch result from OnPost()
            var result = PageModel.OnPostGuidelines() as RedirectToPageResult;

            //  Assert

            //check return null when OnPost
            Assert.AreEqual(null, result);
        }

        #endregion OnPost
    }
}
