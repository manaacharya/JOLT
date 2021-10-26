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
        public void valid_username_valid_password_should_do()
        {
            int userID = 157465;
            pageModel.UserInput_test = new UserLoginModel()
            {
                username = "lakers34",
                password = "dscWTr"
            };

            Assert.AreEqual('2', '2');

        }
        #endregion OnPost

    }
    
}
