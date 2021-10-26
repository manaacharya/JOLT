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
        public static LoginPageModel pageModel;

        [SetUp]

        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<LoginPageModel>>();

            pageModel = new LoginPageModel(MockLoggerDirect, TestHelper.UserService)
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
            pageModel.UserInput_test = new UserLoginModel()
            {
                username = "lakers34",
                password = "dscWTr"
            };
            // pageModel.PageContext.HttpContext.Response.Cookies.Append("nameCookie", "lakers34");
            
            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;
            
            // Reset
            // pageModel.PageContext.HttpContext.Response.Cookies.Delete("nameCookie");
            
            // Assert
            Assert.AreEqual(true, String.IsNullOrEmpty(pageModel.Msg));
            Assert.AreEqual(true, result.PageName.Contains("Login_Welcome"));
            Assert.AreEqual("lakers34", TestHelper.UserService.GetUser(userID).username);
        }

        public void Null_Username_Null_Password_Should_Display_Error()
        {
            // Arrange
            int userID = 157465;
            pageModel.UserInput_test = new UserLoginModel()
            {
                username = null,
                password = null
            };
            // pageModel.PageContext.HttpContext.Response.Cookies.Append("nameCookie", "lakers34");

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Reset
            // pageModel.PageContext.HttpContext.Response.Cookies.Delete("nameCookie");

            // Assert
            Assert.AreEqual("Invalid Username or Password", pageModel.Msg);
            Assert.AreEqual(true, result.PageName.Contains("Login"));
            Assert.AreEqual("lakers34", TestHelper.UserService.GetUser(userID).username);
        }

        #endregion OnPost
    }
    
}
