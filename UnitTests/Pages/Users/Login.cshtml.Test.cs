using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using ContosoCrafts.WebSite.Pages;
using System;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;

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
            //Arrange
            int userID = 157465;
            // UserLoginModel instance created 
            PageModel.UserInput_test = new UserLoginModel()
            {
                //username
                Username = "lakers34",

                //password 
                Password = "dscWTr"
            };
            // Act
            // Fetch result from OnPost()
            var result = PageModel.OnPost() as RedirectToPageResult;


            // Assert
            //check message is empty 
            Assert.AreEqual(true, String.IsNullOrEmpty(PageModel.Msg));

            //check page is loginwelcome page
            Assert.AreEqual(true, result.PageName.Contains("Login_Welcome"));

            //check username is correct 
            Assert.AreEqual("lakers34", TestHelper.UserService.GetUser(userID).Username);
        }

        /// <summary>
        /// Test for OnPost() Null Username and Password
        /// </summary>
        [Test]
        public void OnPost_Null_Username_Null_Password_Should_Display_Error()
        {
            // Arrange
            // UserLoginModel instance created 
            PageModel.UserInput_test = new UserLoginModel()
            {
            };

            // Act
            // Fetch result from OnPost()
            var result = PageModel.OnPost() as RedirectToPageResult;

            // Reset

            // Assert
            //check message 
            Assert.AreEqual("No Empty Entry", PageModel.Msg);

            //check return result is null 
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// Test for OnPost Valid name, Invalid Password
        /// </summary>
        [Test]
        public void OnPost_Valid_Username_Incorrect_Password_Should_Display_Error()
        {
            //Arrange-
            // UserLoginModel instance created 
            PageModel.UserInput_test = new UserLoginModel()
            {
                //username 
                Username = "lakers34",

                //incorrect password 
                Password = "INCORRECT_PASSWORD"
            };

            // Act
            // Fetch result from OnPost()
            var result = PageModel.OnPost() as RedirectToPageResult;

            // Reset

            // Assert

            //check message for incorrect password 
            Assert.AreEqual("Invalid Username or Password", PageModel.Msg);

            //check return result is null 
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// Test for OnPost Incorrect name and Password
        /// </summary>
        [Test]
        public void OnPost_Incorrect_Username_Incorrect_Password_Should_Display_Error()
        {
            // Arrange
            // UserLoginModel instance created 
            PageModel.UserInput_test = new UserLoginModel()
            {
                //incorrect username 
                Username = "INCORRECT_USERNAME",

                //incorrect password 
                Password = "INCORRECT_PASSWORD"
            };

            // Act
            // Fetch result from OnPost()
            var result = PageModel.OnPost() as RedirectToPageResult;

            // Reset

            // Assert
            //check message is inocrrect password/username 
            Assert.AreEqual("Invalid Username or Password", PageModel.Msg);

            //check return result is null 
            Assert.AreEqual(null, result);
        }

        #endregion OnPost
    }
    
}
