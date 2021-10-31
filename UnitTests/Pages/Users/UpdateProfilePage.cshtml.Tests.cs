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
    class UpdateProfilePage
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

        #region OnPost
        [Test]
        public void OnPost_Valid_UserModel_Should_Update_User()
        {
            // Valid Update

            // ---- Arrange ----
            int userID = 862765;
            PageModel.UpdateUser = new UpdateUserModel()
            {
                UpdateID = userID,
                UpdateName = "TestName",
                UpdatePassword = "TestPassword",
                UpdateEmail = "Test123@gmail.com",
                UpdateLocation = "Canada"
            };

            PageModel.PageContext.HttpContext.Response.Cookies.Append("nameCookie", "craigs34");

            // ---- Act ----
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ---- Reset ----

           // var getUser = TestHelper.UserService.GetUser(userID);
            // ---- Assert ----

            Assert.AreEqual(true, result.PageName.Contains("ProfilePage"));
            // Confirm User Is Updated
            Assert.AreEqual("Update Successful to 862765, Name: TestName", PageModel.Message);
        }

        [Test]
        public void OnPost_InValid_ModelState_Should_Return_Page()
        {
            // ---- Arrange ----

            // Force an invalid error state
            PageModel.ModelState.AddModelError("no update", "No Updates Made");

            // ---- Act ----
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ---- Assert ----
            Assert.AreEqual(false, PageModel.ModelState.IsValid);
        }

        [Test]
        public void OnPost_InValid_UserModel_Should_Return_Page()
        {
            // InValid Update
            // ---- Arrange ----
            int invalidID = 999999;

            PageModel.UpdateUser = new UpdateUserModel()
            {
                UpdateID = invalidID,
                UpdateName = "BogusName",
                UpdatePassword = "BogusPassword",
                UpdateEmail = "bogus123@gmail.com",
                UpdateLocation = "Bogus"
            };

            // ---- Act ----
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ---- Reset ----

            // ---- Assert ----
            var errorMessage = PageModel.Message;
            Assert.AreEqual(errorMessage, "Error Updating BogusName");

        }

        #endregion OnPost
    }
}
