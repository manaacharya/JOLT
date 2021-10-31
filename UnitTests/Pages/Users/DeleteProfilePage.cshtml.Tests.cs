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

        #region OnPostDeleteProfile
        [Test]
        public void OnPost_Valid_UserModel_Should_Delete_UserObject()
        {
            // Arrange
            //valid ID 
            int userID = 343386;
            PageModel.PageContext.HttpContext.Response.Cookies.Append("nameCookie", "craigs34");

            // Act
            var result = PageModel.OnPostDeleteProfile(userID) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            //var name = result.PageName;
            //Assert.AreEqual(true, result.PageName.Contains("Index"));
            Assert.AreEqual(null, PageModel.PageContext.HttpContext.Request.Cookies["nameCookie"]);

            //confirm

            Assert.AreEqual("User deleted.", PageModel.Message); 

            // Confirm the item is deleted
          
            
        }

        [Test]
        public void OnPost_InValid_UserModel_Should_Return_Page()
        {
            // Arrange

            int invalidId = -93939;

            // Act
            var result = PageModel.OnPostDeleteProfile(invalidId) as RedirectToPageResult;

            // Reset

            // Assert
            Assert.AreEqual("ProfilePage", result.PageName);
            Assert.AreEqual("User Not Deleted", PageModel.Message);


        }

        #endregion OnPostDeleteProfile 
    }
};