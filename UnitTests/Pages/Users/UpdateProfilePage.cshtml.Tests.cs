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
        /// <summary>
        /// ProfilePage Model static field/attribute
        /// </summary>
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
            // Arrange
            //use existing userID
            int userID = 862765;

            //new User object 
            PageModel.UpdateUser = new UpdateUserModel()
            {
                //userID
                UpdateID = userID,

                //username 
                UpdateName = "TestName",

                //password
                UpdatePassword = "TestPassword",

                //email 
                UpdateEmail = "Test123@gmail.com",

                //location 
                UpdateLocation = "Canada"
            };

            PageModel.PageContext.HttpContext.Response.Cookies.Append("nameCookie", "craigs34");

            // Act
            // Fetch result from Post
            var result = PageModel.OnPost() as RedirectToPageResult;

            // Reset

            //Assert
            //check page is profile page 
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
            //Arrange

            // Force an invalid error state
            PageModel.ModelState.AddModelError("no update", "No Updates Made");

            // Act
            // Fetch result from Post
            var result = PageModel.OnPost() as RedirectToPageResult;

            // Assert
            //check that model state is not valid 
            Assert.AreEqual(false, PageModel.ModelState.IsValid);
        }

        /// <summary>
        /// Test for OnPost InValid UserModel
        /// </summary>
        [Test]
        public void OnPost_InValid_UserModel_Should_Return_Page()
        {
            // Arrange
            // invalid id variable
            int invalidID = 999999;

            //create new user object
            PageModel.UpdateUser = new UpdateUserModel()
            {
                //invalid user id 
                UpdateID = invalidID,

                //username 
                UpdateName = "BogusName",

                //password 
                UpdatePassword = "BogusPassword",

                //email 
                UpdateEmail = "bogus123@gmail.com",

                //location 
                UpdateLocation = "Bogus"
            };

            //Act
            // Fetch result from Post
            var result = PageModel.OnPost() as RedirectToPageResult;

            //Reset

            // Assert
            //fetch error message
            var errorMessage = PageModel.Message;

            //check error message 
            Assert.AreEqual(errorMessage, "Error Updating BogusName");

        }

        #endregion OnPost
    }
}