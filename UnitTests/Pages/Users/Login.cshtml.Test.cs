using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;

using System;
using System.Collections.Generic;
using System.Linq;


using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace UnitTests.Pages.Users
{
    /// <summary>
    /// LoginTest class for Login
    /// </summary>
    class LoginTest
    {
        #region TestSetup
        // LoginPage Model static field/attribute
        public static LoginPageModel PageModel;

        /// <summary>
        /// Test Initialization for LoginPage
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // logging attribute created
            var MockLoggerDirect = Mock.Of<ILogger<LoginPageModel>>();

            // Login Model instance created with logging attribute passed in constructor
            PageModel = new LoginPageModel(MockLoggerDirect, TestHelper.UserService)
            {
                // Set the Page Context
                PageContext = TestHelper.PageContext
            };

        }
        #endregion TestSetup

        #region OnPost

        /// <summary>
        /// Test For OnPost() on Valid User and Password
        /// </summary>
        [Test]
        public void OnPost_Valid_Username_Valid_Password_Should_Return_Login_Welcome()
        {
            // ----------------- Arrange -----------------
            int userID = 157465;
            // UserLoginModel instance created 
            PageModel.UserInput_test = new UserLoginModel()
            {
                Username = "lakers34",
                Password = "dscWTr"
            };
            // ----------------- Act -----------------
            // Fetch result from OnPost()
            var result = PageModel.OnPost() as RedirectToPageResult;

            // Reset

            // ----------------- Assert -----------------
            Assert.AreEqual(true, String.IsNullOrEmpty(PageModel.Msg));
            Assert.AreEqual(true, result.PageName.Contains("Login_Welcome"));
            Assert.AreEqual("lakers34", TestHelper.UserService.GetUser(userID).Username);
        }

        /// <summary>
        /// Test for OnPost() Null Username and Password
        /// </summary>
        [Test]
        public void OnPost_Null_Username_Null_Password_Should_Display_Error()
        {
            // ----------------- Arrange -----------------
            // UserLoginModel instance created 
            PageModel.UserInput_test = new UserLoginModel()
            {
            };

            // ----------------- Act -----------------
            // Fetch result from OnPost()
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------
            Assert.AreEqual("No Empty Entry", PageModel.Msg);
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// Test for OnPost Valid name, Invalid Password
        /// </summary>
        [Test]
        public void OnPost_Valid_Username_Incorrect_Password_Should_Display_Error()
        {
            // ----------------- Arrange -----------------
            // UserLoginModel instance created 
            PageModel.UserInput_test = new UserLoginModel()
            {
                Username = "lakers34",
                Password = "INCORRECT_PASSWORD"
            };

            // ----------------- Act -----------------
            // Fetch result from OnPost()
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------
            Assert.AreEqual("Invalid Username or Password", PageModel.Msg);
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// Test for OnPost Incorrect name and Password
        /// </summary>
        [Test]
        public void OnPost_Incorrect_Username_Incorrect_Password_Should_Display_Error()
        {
            // ----------------- Arrange -----------------
            // UserLoginModel instance created 
            PageModel.UserInput_test = new UserLoginModel()
            {
                Username = "INCORRECT_USERNAME",
                Password = "INCORRECT_PASSWORD"
            };

            // ----------------- Act -----------------
            // Fetch result from OnPost()
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------
            Assert.AreEqual("Invalid Username or Password", PageModel.Msg);
            Assert.AreEqual(null, result);
        }

        #endregion OnPost
    }
    
}
