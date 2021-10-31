using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace UnitTests.Pages.Users
{
    class LoginTest
    {
        #region TestSetup
        public static LoginPageModel PageModel;

        [SetUp]

        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<LoginPageModel>>();

            PageModel = new LoginPageModel(MockLoggerDirect, TestHelper.UserService)
            {
                PageContext = TestHelper.PageContext
            };

        }
        #endregion TestSetup

        #region OnPost
        [Test]
        public void Valid_Username_Valid_Password_Should_Return_Login_Welcome()
        {   
            // Arrange
            int userID = 157465;
            PageModel.UserInput_test = new UserLoginModel()
            {
                Username = "lakers34",
                Password = "dscWTr"
            };
            // pageModel.PageContext.HttpContext.Response.Cookies.Append("nameCookie", "lakers34");
            
            // Act
            var result = PageModel.OnPost() as RedirectToPageResult;
            
            // Reset
            // pageModel.PageContext.HttpContext.Response.Cookies.Delete("nameCookie");
            
            // Assert
            Assert.AreEqual(true, String.IsNullOrEmpty(PageModel.Msg));
            Assert.AreEqual(true, result.PageName.Contains("Login_Welcome"));
            Assert.AreEqual("lakers34", TestHelper.UserService.GetUser(userID).Username);
        }

        [Test]
        public void Null_Username_Null_Password_Should_Display_Error()
        {
            // Arrange
            PageModel.UserInput_test = new UserLoginModel()
            {
            };
            // pageModel.PageContext.HttpContext.Response.Cookies.Append("nameCookie", "lakers34");

            // Act
            var result = PageModel.OnPost() as RedirectToPageResult;

            // Reset
            // pageModel.PageContext.HttpContext.Response.Cookies.Delete("nameCookie");

            // Assert
            Assert.AreEqual("No Empty Entry", PageModel.Msg);
            Assert.AreEqual(null, result);
            //Assert.AreEqual(true, result.PageName.Contains("Login"));
        }

        [Test]
        public void Valid_Username_Incorrect_Password_Should_Display_Error()
        {
            // Arrange
            PageModel.UserInput_test = new UserLoginModel()
            {
                Username = "lakers34",
                Password = "INCORRECT_PASSWORD"
            };
            // pageModel.PageContext.HttpContext.Response.Cookies.Append("nameCookie", "lakers34");

            // Act
            var result = PageModel.OnPost() as RedirectToPageResult;

            // Reset
            // pageModel.PageContext.HttpContext.Response.Cookies.Delete("nameCookie");

            // Assert
            Assert.AreEqual("Invalid Username or Password", PageModel.Msg);
            Assert.AreEqual(null, result);
            //Assert.AreEqual(true, result.PageName.Contains("Login"));
        }

        [Test]
        public void Incorrect_Username_Incorrect_Password_Should_Display_Error()
        {
            // Arrange
            PageModel.UserInput_test = new UserLoginModel()
            {
                Username = "INCORRECT_USERNAME",
                Password = "INCORRECT_PASSWORD"
            };
            // pageModel.PageContext.HttpContext.Response.Cookies.Append("nameCookie", "lakers34");

            // Act
            var result = PageModel.OnPost() as RedirectToPageResult;

            // Reset
            // pageModel.PageContext.HttpContext.Response.Cookies.Delete("nameCookie");

            // Assert
            Assert.AreEqual("Invalid Username or Password", PageModel.Msg);
            Assert.AreEqual(null, result);
            //Assert.AreEqual(true, result.PageName.Contains("Login"));
        }


        #endregion OnPost
    }
    
}
