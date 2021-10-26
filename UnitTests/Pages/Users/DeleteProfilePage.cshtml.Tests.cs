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
    class DeleteProfilePage
    {
        #region TestSetup
        public static ProfilePageModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<ProfilePageModel>>();

            pageModel = new ProfilePageModel(MockLoggerDirect, TestHelper.UserService)
            {
                PageContext = TestHelper.PageContext
            };
        }

        #endregion TestSetup 

        #region OnPostDeleteProfile
        [Test]
        public void OnPost_Valid_UserModel_Should_Delete_UserObject()
        {
            // Arrange
            // First Create the product to delete
            var user = new UserModel()
            {
                username = "TestName",
                password = "TestPassword",
                email = "Test123@gmail.com",
                location = "Canada"
            };

            pageModel.UserModel = TestHelper.UserService.CreateData(user);

            // Act
            string id = user.userID.ToString();
            var result = pageModel.OnPostDeleteProfile(id) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.UserService.GetUser(id).username);
        }
        #endregion OnPostDeleteProfile 
    }
};