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
    class RegisterTest
    {
        #region TestSetup
        public static RegisterModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<RegisterModel>>();

            pageModel = new RegisterModel(MockLoggerDirect, TestHelper.UserService)
            {
                PageContext = TestHelper.PageContext
            };
        }

        #endregion TestSetup

        #region OnPost
        [Test]
        public void OnPost_Valid_Post_Should_Return_To_Index()
        {
            // Valid Update

            // ---- Arrange ----
            var oldCount = TestHelper.UserService.GetUsers().Count();

            Random rnd = new Random();
            int userID = rnd.Next(1, 999999);
            pageModel.BindUser = new UserModel()
            {
                userID = userID,
                username = "TestValidName",
                password = "TestValidPassword",
                email = "TestValidEmail@gmail.com",
                location = "TestValidLocation"
            };

            // ---- Act ----
            var result = pageModel.OnPost() as RedirectToPageResult;

            // ---- Reset ----

            // ---- Assert ----

            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            // Confirm that record was created
            Assert.AreEqual(oldCount + 1, TestHelper.UserService.GetUsers().Count());
        }

        

        #endregion OnPost
    }
    
}
