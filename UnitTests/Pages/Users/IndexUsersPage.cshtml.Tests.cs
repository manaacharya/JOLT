using System.Linq;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Users
{
    /// <summary>
    /// IndexUsersPage for Users Page
    /// </summary>
    class IndexUsersPage
    {
        #region TestSetup
        // Users Page Model static field/attribute
        public static UsersPageModel UsersPageModel;

        /// <summary>
        /// Test Initialization for UsersPage 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // logging attribute created
            var MockLoggerDirect = Mock.Of<ILogger<UsersPageModel>>();

            // UsersPage Model instance created with logging attribute passed in constructor
            UsersPageModel = new UsersPageModel(MockLoggerDirect, TestHelper.UserService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test for OnGet() Collection of Users
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Users()
        {
            //Arrange

            // Act

            // Fetch result from OnGet()
            UsersPageModel.OnGet();

            // Assert

            //check model state is valid 
            Assert.AreEqual(true, UsersPageModel.ModelState.IsValid);

            //check Users list is filled 
            Assert.AreEqual(true, UsersPageModel.Users.ToList().Any());
        }
        #endregion OnGet

    }
}
