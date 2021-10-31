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

        public static UsersPageModel UsersPageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<UsersPageModel>>();

            UsersPageModel = new UsersPageModel(MockLoggerDirect, TestHelper.UserService)
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
            UsersPageModel.OnGet();

            // Assert
            Assert.AreEqual(true, UsersPageModel.ModelState.IsValid);
            Assert.AreEqual(true, UsersPageModel.Users.ToList().Any());
        }
        #endregion OnGet

    }
}
