using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using System.Linq;

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
            PageModel = new IndexModel(MockLoggerDirect, TestHelper.PollService, TestHelper.UserService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test for OnGet() Valid Products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Get_Polls ()
        {
            //Arrange

            // Valid User Cookie
            PageModel.CookieNameValue = "viner765";

            //Act

            // fetch onget 
            PageModel.OnGet();

            // Assert

            // check model state is valid 
            Assert.AreEqual(true, PageModel.ModelState.IsValid);

            // Making Sure It Went to the PollsPage
            Assert.AreEqual(true, PageModel.PollModels.ToList().Any());

            // Assert Cookie Value
            Assert.AreEqual(true, PageModel.CookieNameValue.Equals("viner765"));

            // Check Message for User
            Assert.AreEqual(true, PageModel.Message.Equals("Must Be Logged In To Create Poll"));
        }
        #endregion OnGet
    }
}