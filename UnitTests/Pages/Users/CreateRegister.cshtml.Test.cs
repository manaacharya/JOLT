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
        public static RegisterModel PageModel;

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<RegisterModel>>();

            PageModel = new RegisterModel(MockLoggerDirect, TestHelper.UserService)
            {
                PageContext = TestHelper.PageContext
            };
        }

        #endregion TestSetup

        #region OnPost
        [Test]
        public void OnPost_Valid_Post_Should_Add_New_Record()
        {
            // Valid Update

            // ---- Arrange ----
            var oldCount = TestHelper.UserService.GetUsers().Count();

            Random rnd = new Random();
            int userID = rnd.Next(1, 999999);
            PageModel.BindUser = new UserModel()
            {
                UserID = userID,
                Username = "TestValidName",
                Password = "TestValidPassword",
                Email = "TestValidEmail@gmail.com",
                Location = "TestValidLocation"
            };

            // ---- Act ----
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ---- Reset ----

            // ---- Assert ----

            Assert.AreEqual(true, PageModel.ModelState.IsValid);
            // Confirm that record was created
            Assert.AreEqual(oldCount + 1, TestHelper.UserService.GetUsers().Count());
        }

        [Test]
        public void OnPost_InValid_Username_Should_Not_Add_New_Record()
        {
            // Valid Update

            // ---- Arrange ----
            var oldCount = TestHelper.UserService.GetUsers().Count();

            Random rnd = new Random();
            int userID = rnd.Next(1, 999999);

            PageModel.BindUser = new UserModel()
            {
                UserID = userID,
                Username = "User@@@", //should only contain numbers and letter
                Password = "TestValidpassword", //password is less than 6
                Email = "TestvalidEmail@gmail.com",
                Location = "TestvalidLocation"
            };


            // ---- Act ----
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ---- Reset ----

            // ---- Assert ---
            // Confirm that no new recorded was added
            Assert.AreEqual(oldCount, TestHelper.UserService.GetUsers().Count());
        }

        [Test]
        public void OnPost_InValid_Password_Should_Not_Add_New_Record()
        {
            // Valid Update

            // ---- Arrange ----
            var oldCount = TestHelper.UserService.GetUsers().Count();

            Random rnd = new Random();
            int userID = rnd.Next(1, 999999);

            PageModel.BindUser = new UserModel()
            {
                UserID = userID,
                Username = "TestValidUsername",
                Password = "pass", //password should be more than 6
                Email = "TestvalidEmail@gmail.com",
                Location = "TestvalidLocation"
            };


            // ---- Act ----
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ---- Reset ----

            // ---- Assert ---
            // Confirm that no new recorded was added
            Assert.AreEqual(oldCount, TestHelper.UserService.GetUsers().Count());
        }

        [Test]
        public void OnPost_InValid_Email_Should_Not_Add_New_Record()
        {
            // Valid Update

            // ---- Arrange ----
            var oldCount = TestHelper.UserService.GetUsers().Count();

            Random rnd = new Random();
            int userID = rnd.Next(1, 999999);

            PageModel.BindUser = new UserModel()
            {
                UserID = userID,
                Username = "TestValidUsername",
                Password = "TestValidpassword",
                Email = "TestvalidEmail@gmail", //email should be in valid format
                Location = "TestvalidLocation"
            };


            // ---- Act ----
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ---- Reset ----

            // ---- Assert ---
            // Confirm that no new recorded was added
            Assert.AreEqual(oldCount, TestHelper.UserService.GetUsers().Count());
        }

        [Test]
        public void OnPost_InValid_Location_Should_Not_Add_New_Record()
        {
            // Valid Update

            // ---- Arrange ----
            var oldCount = TestHelper.UserService.GetUsers().Count();

            Random rnd = new Random();
            int userID = rnd.Next(1, 999999);

            PageModel.BindUser = new UserModel()
            {
                UserID = userID,
                Username = "TestValidUsername",
                Password = "TestValidpassword",
                Email = "TestvalidEmail@gmail.com",
                Location = "TestInvalidLocation!!!!" //should only contain letters
            };


            // ---- Act ----
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ---- Reset ----

            // ---- Assert ---
            // Confirm that no new recorded was added
            Assert.AreEqual(oldCount, TestHelper.UserService.GetUsers().Count());
        }
        #endregion OnPost
    }
    
}
