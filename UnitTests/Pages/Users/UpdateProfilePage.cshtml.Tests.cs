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
    /// <summary>
    /// UpdateProfilePage Class for Update 
    /// </summary>
    class UpdateProfilePage
    {
        #region TestSetup
        // ProfilePage Model static field/attribute
        public static ProfilePageModel PageModel;

        /// <summary>
        /// Test Initialization for ProfilePage
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // logging attribute created
            var MockLoggerDirect = Mock.Of<ILogger<ProfilePageModel>>();

            // Profile Model instance created with logging attribute passed in constructor
            PageModel = new ProfilePageModel(MockLoggerDirect, TestHelper.UserService)
            {
                // Set the Page Context
                PageContext = TestHelper.PageContext
            };
        }

        #endregion TestSetup

        #region OnPost
        /// <summary>
        /// Test for OnPost() Valid UserModel 
        /// </summary>
        [Test]
        public void OnPost_Valid_UserModel_Should_Update_User()
        {
            // ----------------- Arrange -----------------
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

            // --------------------- Act -----------------
            // Fetch result from Post
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ---- Assert ----

            Assert.AreEqual(true, result.PageName.Contains("ProfilePage"));
            // Confirm User Is Updated
            Assert.AreEqual("Update Successful to 862765, Name: TestName", PageModel.Message);
        }

        /// <summary>
        /// Test for OnPost InValid Model State
        /// </summary>
        [Test]
        public void OnPost_InValid_ModelState_Should_Return_Page()
        {
            // ----------------- Arrange -----------------

            // Force an invalid error state
            PageModel.ModelState.AddModelError("no update", "No Updates Made");

            // ----------------- Act -----------------
            // Fetch result from Post
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Assert -----------------
            Assert.AreEqual(false, PageModel.ModelState.IsValid);
        }

        /// <summary>
        /// Test for OnPost InValid UserModel
        /// </summary>
        [Test]
        public void OnPost_InValid_UserModel_Should_Return_Page()
        {
            // ----------------- Arrange -----------------
            // invalid id variable
            int invalidID = 999999;

            PageModel.UpdateUser = new UpdateUserModel()
            {
                UpdateID = invalidID,
                UpdateName = "BogusName",
                UpdatePassword = "BogusPassword",
                UpdateEmail = "bogus123@gmail.com",
                UpdateLocation = "Bogus"
            };

            // ----------------- Act -----------------
            // Fetch result from Post
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------
            var errorMessage = PageModel.Message;
            Assert.AreEqual(errorMessage, "Error Updating BogusName");

        }

        #endregion OnPost
    }
}
