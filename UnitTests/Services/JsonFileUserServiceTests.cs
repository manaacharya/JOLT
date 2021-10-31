using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;



namespace UnitTests.Services
{
    public class JsonFileUserServiceTests
    {
        #region TestSetup
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region UpdateProfile

        [Test]
        public void UpdateProfile_InValidId_InValidUpdateUserModel_Should_Return_Null()
        {
            // Arrange
            int invalidId = 999999;

            UpdateUserModel updateUserModel = new UpdateUserModel()
            {
                UpdateID = invalidId,
                UpdateName = "Invalid Name",
                UpdateEmail = "invalid@gmail.com",
                UpdatePassword = "Invalidpassword",
                UpdateLocation = "USA"
            };

            // Act
            var getResult = TestHelper.UserService.UpdateProfile(updateUserModel);

            // Reset

            // Assert

            Assert.AreEqual(null, getResult);
        }

        [Test]
        public void UpdateProfile_ValidId_ValidUpdateUserModel_Should_Return_UserModel()
        {
            // Arrange
            int validId = 862765;

            UpdateUserModel updateUserModel = new UpdateUserModel()
            {
                UpdateID = validId,
                UpdateName = "Valid Name",
                UpdateEmail = "valid@gmail.com",
                UpdatePassword = "ValidPassword",
                UpdateLocation = "USA"
            };

            // Act
            UserModel getResult = TestHelper.UserService.UpdateProfile(updateUserModel);

            // Reset
            
            // Arrange

            // Confirm Update Has Gone Through
            Assert.AreEqual(true, getResult.UserID.Equals(updateUserModel.UpdateID));
            Assert.AreEqual(true, getResult.Email.Equals(updateUserModel.UpdateEmail));
            Assert.AreEqual(true, getResult.Password.Equals(updateUserModel.UpdatePassword));

        }

        #endregion UpdateProfile

        #region GetUser

        [Test]
        public void GetUser_ValidID_Should_Return_UserModel()
        {
            // Arrange
            int validId = 491376;

            // Act

            UserModel userModel = TestHelper.UserService.GetUser(validId);

            // Reset

            // Assert
            Assert.AreEqual(true, userModel.UserID.Equals(validId));
            Assert.AreEqual(true, userModel.Username.Equals("calif32"));
            Assert.AreEqual(true, userModel.Location.Equals("United States of America"));
        }

        [Test]
        public void GetUser_InValidID_Should_Return_Null()
        {
            // Arrange
            int invalidId = 000000;

            // Act
            UserModel userModel = TestHelper.UserService.GetUser(invalidId);

            // Reset

            // Assert
            Assert.AreEqual(null, userModel);
        }

        [Test]
        public void GetUser_ValidName_Should_Return_UserModel()
        {
            // Arrange
            string validName = "calif32";

            // Act

            UserModel userModel = TestHelper.UserService.GetUser(validName);

            // Reset

            // Assert
            Assert.AreEqual(true, userModel.UserID.Equals(491376));
            Assert.AreEqual(true, userModel.Username.Equals("calif32"));
            Assert.AreEqual(true, userModel.Location.Equals("United States of America"));
        }

        [Test]
        public void GetUser_InValidName_Should_Return_Null()
        {
            // Arrange
            string invalidName = "InvalidName";

            // Act
            UserModel userModel = TestHelper.UserService.GetUser(invalidName);

            // Reset

            // Assert
            Assert.AreEqual(null, userModel);
        }

        #endregion GetUser

        #region GetPassword

        [Test]
        public void GetPassword_ValidName_Should_Return_Password()
        {
            // Arrange
            string validName = "calif32";

            // Act

            string getPassword = TestHelper.UserService.GetPassWord(validName);

            // Reset

            // Assert
            Assert.AreEqual(true, getPassword.Equals("vDEkwE"));
        }

        [Test]
        public void GetPassword_InValidName_Should_Return_Null()
        {
            // Arrange
            string invalidName = "000000";

            // Act
            string getPassword = TestHelper.UserService.GetPassWord(invalidName);

            // Reset

            // Assert
            Assert.AreEqual(null, getPassword);
        }

        #endregion GetPassword

        #region IsCorrectPassword

        [Test]
        public void isCorrectPassword_ValidName_ValidPassword_Should_Return_True()
        {
            // Arrange

            // Valid UserName and Password
            string userName = "calif32";
            string password = "vDEkwE";

            // Act
            bool result = TestHelper.UserService.IsCorrectPassword(userName, password);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void isCorrectPassword_InValidName_InValidPassword_Should_Return_False()
        {
            // Arrange
            string invalidName = "008998832";
            string invalidPassword = "vDEkwE";

            // Act
            bool result = TestHelper.UserService.IsCorrectPassword(invalidName, invalidPassword);

            // Reset
            // Assert

            Assert.AreEqual(false, result);
        }

        [Test]
        public void isCorrectPassword_ValidName_InValidPassword_Should_Return_False()
        {
            // Arrange
            string userName = "calif32";
            string invalidPassword = "613841";

            // Act
            bool result = TestHelper.UserService.IsCorrectPassword(userName, invalidPassword);

            // Reset

            // Assert
            // Invalid Passowrd
            Assert.AreEqual(false, result);
        }

        #endregion isCorrectPassword

        #region CreateData

        [Test]
        public void CreateData_New_UserModel_Should_Return_UserModel()
        {
            // Arrange
            UserModel newUser = new UserModel()
            {
                Username = "Kitchen",
                Email = "KitchenNightMare@gmail.com",
                Password = "kitchepassword",
                Location = "Cuba"
            };

            // Act
            UserModel userModel = TestHelper.UserService.CreateData(newUser);

            // Reset
            // Assert
            Assert.AreEqual(true, userModel.Username.Equals(newUser.Username));
            Assert.AreEqual(true, userModel.Email.Equals(newUser.Email));
            Assert.AreEqual(true, userModel.Password.Equals(newUser.Password));
            Assert.AreEqual(true, userModel.Location.Equals(newUser.Location));
        }

        #endregion CreateData

        #region DeleteData

        [Test]
        public void DeleteData_ValidId_Should_Return_True()
        {
            // Arrange
            int validId = 341292;

            // Act
            bool getResult = TestHelper.UserService.DeleteData(validId);

            // Reset
            // Assert
            Assert.AreEqual(true, getResult);

        }

        [Test]
        public void DeleteData_InValidId_Should_Return_False()
        {
            // Arrange
            int invalidId = 111111;

            // Act
            bool getResult = TestHelper.UserService.DeleteData(invalidId);

            // Reset
            // Assert
            Assert.AreEqual(false, getResult);
        }

        #endregion DeleteData


        #region CreateCookie

        [Test]
        public void CreateCookie_ValidKey_ValidValue_Should_AddCookie()
        {
            // Arrange
            string key = "testName";
            string value = "testkey";

            // Act
            bool result = TestHelper.UserService.CreateCookie(key, value);
            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual("testkey", TestHelper.UserService.GetCookieValue(key));

        }

        [Test]
        public void CreateCookie_KeyExist_Should_Return_False()
        {
            // Arrange
            string key = "duplicateKey";
            string value = "duplicateValue";

            TestHelper.UserService.CreateCookie(key, value);

            // Act
            bool result = TestHelper.UserService.CreateCookie(key, value);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        #endregion CreateCookie

        #region GetCookieValue

        [Test]
        public void GetCookieValue_ValidKey_Should_Return_CookieValue()
        {
            // Arrange
            string key = "newkey";
            string value = "newValue";

            TestHelper.UserService.CreateCookie(key, value);

            // Act
            string result = TestHelper.UserService.GetCookieValue(key);

            // Reset

            // Assert
            Assert.AreEqual("newValue", result);
        }

        [Test]
        public void GetCookieValue_InValidKey_Should_Return_Null()
        {
            // Arrange
            string key = "newkey";
            string value = "newValue";

            string invalidKey = "fakekey";

            TestHelper.UserService.CreateCookie(key, value);

            // Act
            string result = TestHelper.UserService.GetCookieValue(invalidKey);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        #endregion GetCookieValue


        #region DeleteCookie
        [Test]
        public void DeleteCookie_ValidKey_Should_Return_True()
        {
            // Arrange
            string key = "deletekey";
            string value = "deleteValue";

            TestHelper.UserService.CreateCookie(key, value);

            // Act
            bool result = TestHelper.UserService.DeleteCookie(key);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void DeleteCookie_InValidKey_Should_Return_True()
        {
            // Arrange
            string key = "deletekey";
            string value = "deleteValue";

            string invalidKey = "fdjfdfd";

            TestHelper.UserService.CreateCookie(key, value);

            // Act
            bool result = TestHelper.UserService.DeleteCookie(invalidKey);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        #endregion DeleteCookie
    }
}
