using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;

using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Index
{
    /// <summary>
    /// IndexTests Class for Index Page
    /// </summary>
    public class IndexTests
    {
        #region TestSetup

        // Index Model static field/attribute
        public static IndexModel PageModel;

        /// <summary>
        /// Test Initialization for Index Page Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // logging attribute created
            var MockLoggerDirect = Mock.Of<ILogger<IndexModel>>();

            // Index Model instance created with logging attribute passed in constructor
            PageModel = new IndexModel(MockLoggerDirect)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test for OnGet() Valid Products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            //Arrange

            //Act
            //fetch onget 
            var pageResult = PageModel.OnGet() as RedirectToPageResult;

            // Assert
            //check model state is valid 
            Assert.AreEqual(true, PageModel.ModelState.IsValid);

            // Making Sure It Went to the PollsPage
            Assert.AreEqual(true, pageResult.PageName.Contains("./PollsPages/PollsPage"));

        }
        #endregion OnGet
    }
}