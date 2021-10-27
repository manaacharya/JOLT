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
            //valid ID 
            int userID = 343386;
            pageModel.PageContext.HttpContext.Response.Cookies.Append("nameCookie", "craigs34");

            // Act
            var result = pageModel.OnPostDeleteProfile(userID) as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
            Assert.AreEqual(null, pageModel.PageContext.HttpContext.Request.Cookies["nameCookie"]);

            //confirm

            Assert.AreEqual("User deleted.", pageModel.Message); 

            // Confirm the item is deleted
          
            
        }
        #endregion OnPostDeleteProfile 
    }
};