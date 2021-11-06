using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

using ContosoCrafts.WebSite.Pages;

using System;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace UnitTests.Pages.Users
{
    /// <summary>
    /// RegisterTest class for Register
    /// </summary>
    class RegisterTest
    {
        #region TestSetup
        // Register Model static field/attribute
        public static RegisterModel PageModel;

        /// <summary>
        ///  Test Initialization for RegisterPage
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            // logging attribute created
            var MockLoggerDirect = Mock.Of<ILogger<RegisterModel>>();

            // Register Model instance created with logging attribute passed in constructor
            PageModel = new RegisterModel(MockLoggerDirect, TestHelper.UserService)
            {
                // Set the Page Context
                PageContext = TestHelper.PageContext
            };
        }
        #endregion TestSetup

        #region OnPost

        /// <summary>
        /// Test for OnPost Valid UserModel
        /// </summary>
        [Test]
        public void OnPost_Valid_UserModel_Should_Add_New_Record()
        {
            // ----------------- Arrange -----------------
            // oldCount variable for total numbers of Users
            var oldCount = TestHelper.UserService.GetUsers().Count();

            // Random object instance creation
            Random rnd = new Random();
            
            // userID variable with random number
            int userID = rnd.Next(1, 999999);

            // UserModel instance created
            PageModel.BindUser = new UserModel()
            {
                //user id
                UserID = userID,

                //username
                Username = "TestValidName",

                //password
                Password = "TestValidPassword",

                //email
                Email = "TestValidEmail@gmail.com",

                //location 
                Location = "TestValidLocation"
            };

            // ----------------- Act -----------------
            // Fetch result from OnPost()
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------

            Assert.AreEqual(true, PageModel.ModelState.IsValid);

            // Confirm that record was created
            Assert.AreEqual(oldCount + 1, TestHelper.UserService.GetUsers().Count());
        }

        /// <summary>
        /// Test for OnPost InValid UserModel
        /// </summary>
        [Test]
        public void OnPost_InValid_UserModel_Name_Should_Not_Add_New_Record()
        {
            // ----------------- Arrange -----------------
            // oldCount variable for total numbers of Users
            var oldCount = TestHelper.UserService.GetUsers().Count();

            // Random object instance creation
            Random rnd = new Random();

            // userID variable with random number
            int userID = rnd.Next(1, 999999);

            // UserModel instance created
            PageModel.BindUser = new UserModel()
            {
                UserID = userID,

                Username = "User@@@", //should only contain numbers and letter

                Password = "TestValidpassword", //password is less than 6

                Email = "TestvalidEmail@gmail.com",

                Location = "TestvalidLocation"
            };


            // ----------------- Act -----------------
            // Fetch result from OnPost()
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------
            // Confirm that no new recorded was added
            Assert.AreEqual(oldCount, TestHelper.UserService.GetUsers().Count());
        }

        /// <summary>
        /// Test for OnPost Invalid UserModel password
        /// </summary>
        [Test]
        public void OnPost_InValid_UserModel_Password_Should_Not_Add_New_Record()
        {
            // ----------------- Arrange -----------------

            var oldCount = TestHelper.UserService.GetUsers().Count();

            // Random object instance creation
            Random rnd = new Random();

            int userID = rnd.Next(1, 999999);

            // UserModel instance created
            PageModel.BindUser = new UserModel()
            {
                //id 
                UserID = userID,

                //username 
                Username = "TestValidUsername",

                //password to fail 
                Password = "pass", //password should be more than 6

                //email 
                Email = "TestvalidEmail@gmail.com",

                //location 
                Location = "TestvalidLocation"
            };


            // ----------------- Act -----------------
            // Fetch result from OnPost
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------
            // Confirm that no new recorded was added
            Assert.AreEqual(oldCount, TestHelper.UserService.GetUsers().Count());
        }

        /// <summary>
        /// Test for OnPost InValid UserModel Email
        /// </summary>
        [Test]
        public void OnPost_InValid_UserModel_Email_Should_Not_Add_New_Record()
        {
            // ----------------- Arrange -----------------
            var oldCount = TestHelper.UserService.GetUsers().Count();

            // Random object instance creation
            Random rnd = new Random();

            int userID = rnd.Next(1, 999999);

            // UserModel instance created
            PageModel.BindUser = new UserModel()
            {
                //user id 
                UserID = userID,

                //username 
                Username = "TestValidUsername",

                //password 
                Password = "TestValidpassword",

                //email to fail 
                Email = "TestvalidEmail@gmail", //email should be in valid format

                //location 
                Location = "TestvalidLocation"
            };

            // ----------------- Act -----------------
            // Fetch result from OnPost
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------
            // Confirm that no new recorded was added
            Assert.AreEqual(oldCount, TestHelper.UserService.GetUsers().Count());
        }

        /// <summary>
        /// Test for OnPost Invalid UserModel Location
        /// </summary>
        [Test]
        public void OnPost_InValid_Location_Should_Not_Add_New_Record()
        {
            // ----------------- Arrange -----------------
            var oldCount = TestHelper.UserService.GetUsers().Count();

            // Random object instance creation
            Random rnd = new Random();

            int userID = rnd.Next(1, 999999);

            // UserModel instance created
            PageModel.BindUser = new UserModel()
            {
                //user id 
                UserID = userID,

                //username 
                Username = "TestValidUsername",

                //password 
                Password = "TestValidpassword",

                //email
                Email = "TestvalidEmail@gmail.com",

                Location = "TestInvalidLocation!!!!" //should only contain letters
            };

            // ----------------- Act -----------------
            // Fetch result from OnPost
            var result = PageModel.OnPost() as RedirectToPageResult;

            // ----------------- Reset -----------------

            // ----------------- Assert -----------------
            // Confirm that no new recorded was added
            Assert.AreEqual(oldCount, TestHelper.UserService.GetUsers().Count());
        }
        #endregion OnPost
    }
    
}
