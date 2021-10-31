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
    /// DeleteProfilePage for Delete
    /// </summary>
    class DeleteProfilePage
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

        #region OnPostDeleteProfile
        /// <summary>
        /// Test for OnPost(), Delete Valid UserModel
        /// </summary>
        [Test]
        public void OnPost_Valid_UserModel_Should_Delete_UserObject()
        {
            // ----------------- Arrange -----------------
            // Valid id variable
            int userID = 343386;
            
            // ----------------- Act -----------------
            // Fetch result from OnPost
            var result = PageModel.OnPostDeleteProfile(userID) as RedirectToPageResult;

            // ----------------- Assert -----------------
            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            Assert.AreEqual(null, PageModel.PageContext.HttpContext.Request.Cookies["nameCookie"]);

            // Confirm the item is deleted
            Assert.AreEqual("User deleted.", PageModel.Message); 
        }

        /// <summary>
        /// Test for OnPost(), Delete InValid UserModel
        /// </summary>
        [Test]
        public void OnPost_InValid_UserModel_Should_Return_Page()
        {
            // ----------------- Arrange -----------------

            int invalidId = -93939;

            // ----------------- Act -----------------
            // Fetch result from OnPost
            var result = PageModel.OnPostDeleteProfile(invalidId) as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------
            Assert.AreEqual("ProfilePage", result.PageName);
            Assert.AreEqual("User Not Deleted", PageModel.Message);

        }

        #endregion OnPostDeleteProfile 
    }
};