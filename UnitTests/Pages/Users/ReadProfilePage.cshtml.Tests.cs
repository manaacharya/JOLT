using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;


namespace UnitTests.Pages.Users
{
    class ReadProfilePage
    {

        #region TestSetup
        public static ProfilePageModel PageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<ProfilePageModel>>();

            PageModel = new ProfilePageModel(MockLoggerDirect, TestHelper.UserService)
            {
                PageContext = TestHelper.PageContext
            };
        }

        #endregion TestSetup

        #region OnGet

        [Test]
        public void OnGet_Valid_Should_Return_UserModel()
        {
            // Arrange
            string key = "lakers34";

            TestHelper.UserService.CreateCookie("nameCookie", key);

            // Act

            PageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            Assert.AreEqual("lakers34", PageModel.UserModel.Username);
            Assert.AreEqual("Egypt", PageModel.UserModel.Location);

        }

        #endregion OnGet


    }
}
