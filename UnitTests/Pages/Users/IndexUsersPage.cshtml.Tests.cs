using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Users
{
    class IndexUsersPage
    {
        #region TestSetup

        public static UsersPageModel usersPageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<UsersPageModel>>();

            usersPageModel = new UsersPageModel(MockLoggerDirect, TestHelper.UserService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Users()
        {
            // Arrange

            // Act
            usersPageModel.OnGet();

            // Assert
            Assert.AreEqual(true, usersPageModel.ModelState.IsValid);
            Assert.AreEqual(true, usersPageModel.Users.ToList().Any());
        }
        #endregion OnGet

    }
}
