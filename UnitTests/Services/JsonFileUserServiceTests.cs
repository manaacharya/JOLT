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
            Assert.AreEqual(true, getResult.userID.Equals(updateUserModel.UpdateID));
            Assert.AreEqual(true, getResult.email.Equals(updateUserModel.UpdateEmail));
            Assert.AreEqual(true, getResult.password.Equals(updateUserModel.UpdatePassword));

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
            Assert.AreEqual(true, userModel.userID.Equals(validId));
            Assert.AreEqual(true, userModel.username.Equals("calif32"));
            Assert.AreEqual(true, userModel.location.Equals("United States of America"));
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
            Assert.AreEqual(true, userModel.userID.Equals(491376));
            Assert.AreEqual(true, userModel.username.Equals("calif32"));
            Assert.AreEqual(true, userModel.location.Equals("United States of America"));
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

        #region isCorrectPassword

        [Test]
        public void isCorrectPassword_ValidName_ValidPassword_Should_Return_True()
        {
            // Arrange

            // Valid UserName and Password
            string userName = "calif32";
            string password = "vDEkwE";

            // Act
            bool result = TestHelper.UserService.isCorrectPassword(userName, password);

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
            bool result = TestHelper.UserService.isCorrectPassword(invalidName, invalidPassword);

            // Reset
            // Assert

            Assert.AreEqual(false, result);
        }

        [Test]
        public void isCorrectPassword_ValidName_InValidPassword_Should_Return_False()
        {
            // Arrange
            string userName = "calif32";
            string invalidPassword = "vDEkwE";

            // Act
            bool result = TestHelper.UserService.isCorrectPassword(userName, invalidPassword);

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
                username = "Kitchen",
                email = "KitchenNightMare@gmail.com",
                password = "kitchepassword",
                location = "Cuba"
            };

            // Act

            // Reset
            // Assert

        }

        #endregion CreateData
    }
}
