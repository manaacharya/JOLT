using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;
using System.Text.Json;

namespace UnitTests.Services
{
    /// <summary>
    /// JsonFileUserServiceTests Class For UserSerivce Test functions
    /// </summary>
    public class JsonFileUserServiceTests
    {
        #region TestSetup
        /// <summary>
        /// Test Initialization for User Services
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region UpdateProfile
        /// <summary>
        /// Test for Updating Profile with Invalid ID
        /// </summary>
        [Test]
        public void UpdateProfile_InValidId_InValidUpdateUserModel_Should_Return_Null()
        {
            // ------------------------- Arrange -------------------------
            //invalid user id 
            int invalidId = 999999;

            // Create UpdateUserModel model instance
            UpdateUserModel updateUserModel = new UpdateUserModel()
            {
                //invalid user id 
                UpdateID = invalidId,

                //username
                UpdateName = "Invalid Name",

                //email
                UpdateEmail = "invalid@gmail.com",

                //password
                UpdatePassword = "Invalidpassword",

                //location 
                UpdateLocation = "USA"
            };

            // ------------------------- Act -------------------------
            //get updateprofile result 
            var getResult = TestHelper.UserService.UpdateProfile(updateUserModel);

            // Reset

            // ------------------------- Assert -------------------------
            //check that return result is null 
            Assert.AreEqual(null, getResult);
        }

        /// <summary>
        /// Test for Updating Profile with Valid ID
        /// </summary>
        [Test]
        public void UpdateProfile_ValidId_ValidUpdateUserModel_Should_Return_UserModel()
        {
            // ------------------------- Arrange -------------------------
            //already exisiting valid userid 
            int validId = 862765;

            // Create UpdateUserModel model instance
            UpdateUserModel updateUserModel = new UpdateUserModel()
            {
                //userid 
                UpdateID = validId,

                //username
                UpdateName = "Valid Name",

                //email
                UpdateEmail = "valid@gmail.com",

                //password
                UpdatePassword = "ValidPassword",

                //location 
                UpdateLocation = "USA"
            };

            // ------------------------- Act -------------------------
            // Fetch result from Act
            UserModel getResult = TestHelper.UserService.UpdateProfile(updateUserModel);

            // Reset

            // ------------------------- Arrange -------------------------
            // Confirm Update Has Gone Through
            //check userid 
            Assert.AreEqual(true, getResult.UserID.Equals(updateUserModel.UpdateID));

            //check email 
            Assert.AreEqual(true, getResult.Email.Equals(updateUserModel.UpdateEmail));

            //check password 
            Assert.AreEqual(true, getResult.Password.Equals(updateUserModel.UpdatePassword));

        }

        #endregion UpdateProfile

        #region GetUser

        /// <summary>
        /// Test for Getting User with Valid ID
        /// </summary>
        [Test]
        public void GetUser_ValidID_Should_Return_UserModel()
        {
            // ------------------------- Arrange -------------------------
            //valid userid from exisiting user 
            int validId = 491376;

            // ------------------------- Act -------------------------
            // Fetch User Result from Act
            UserModel userModel = TestHelper.UserService.GetUser(validId);

            // ------------------------- Assert -------------------------
            //check userid
            Assert.AreEqual(true, userModel.UserID.Equals(validId));

            //check username 
            Assert.AreEqual(true, userModel.Username.Equals("calif32"));

            //check location 
            Assert.AreEqual(true, userModel.Location.Equals("United States of America"));
        }

        /// <summary>
        /// Test for Getting User With InValid ID
        /// </summary>
        [Test]
        public void GetUser_InValidID_Should_Return_Null()
        {
            // ------------------------- Arrange -------------------------
            //invalid user id 
            int invalidId = 000000;

            // ------------------------- Act -------------------------
            // Fetch User Result From Act
            UserModel userModel = TestHelper.UserService.GetUser(invalidId);

            // ------------------------- Assert -------------------------
            //check usermode is not created 
            Assert.AreEqual(null, userModel);
        }

        /// <summary>
        /// Test for Getting User with Valid Name
        /// </summary>
        [Test]
        public void GetUser_ValidName_Should_Return_UserModel()
        {
            // ------------------------- Arrange -------------------------
            //create valid username name 
            string validName = "calif32";

            // ------------------------- Act -------------------------
            // Fetch User Result From Act
            UserModel userModel = TestHelper.UserService.GetUser(validName);

            // Reset

            // ------------------------- Assert -------------------------
            //check userid
            Assert.AreEqual(true, userModel.UserID.Equals(491376));

            //check username 
            Assert.AreEqual(true, userModel.Username.Equals("calif32"));

            //check location 
            Assert.AreEqual(true, userModel.Location.Equals("United States of America"));
        }

        /// <summary>
        /// Test for Getting User with InValid Name 
        /// </summary>
        [Test]
        public void GetUser_InValidName_Should_Return_Null()
        {
            // ------------------------- Arrange -------------------------
            //create invalid username name 
            string invalidName = "InvalidName";

            // ------------------------- Act -------------------------
            // Fetch User Result From Act
            UserModel userModel = TestHelper.UserService.GetUser(invalidName);

            // Reset

            // ------------------------- Assert -------------------------
            //check that usermodel was not created 
            Assert.AreEqual(null, userModel);
        }

        #endregion GetUser

        #region GetPassword

        /// <summary>
        /// Test for Getting Password from Valid Name
        /// </summary>
        [Test]
        public void GetPassword_ValidName_Should_Return_Password()
        {
            // ------------------------- Arrange -------------------------
            //create valid password 
            string validName = "calif32";

            // ------------------------- Act -------------------------
            // Fetch Password Result From Act
            string getPassword = TestHelper.UserService.GetPassWord(validName);

            // -------------------------  Reset-------------------------

            // ------------------------- Assert -------------------------
            //check password 
            Assert.AreEqual(true, getPassword.Equals("vDEkwE"));
        }

        /// <summary>
        /// Test for Getting Password from InValid Name
        /// </summary>
        [Test]
        public void GetPassword_InValidName_Should_Return_Null()
        {
            // ------------------------- Arrange -------------------------
            //create invalid password 
            string invalidName = "000000";

            // ------------------------- Act -------------------------
            // Fetch Password Result From Act
            string getPassword = TestHelper.UserService.GetPassWord(invalidName);

            // Reset

            // ------------------------- Assert -------------------------
            //check that no usermodel was created 
            Assert.AreEqual(null, getPassword);
        }

        #endregion GetPassword

        #region IsCorrectPassword

        /// <summary>
        /// Test for Whether Valid Name and Valid Password Are linked and exists to  User
        /// </summary>
        [Test]
        public void isCorrectPassword_ValidName_ValidPassword_Should_Return_True()
        {
            // ------------------------- Arrange -------------------------

            // Valid UserName and Password
            string userName = "calif32";
            string password = "vDEkwE";

            // ------------------------- Act -------------------------
            // Fetch Result From Act
            bool result = TestHelper.UserService.IsCorrectPassword(userName, password);

            // Reset

            // ------------------------- Assert -------------------------
            //check return result is correct 
            Assert.AreEqual(true, result);
        }

        /// <summary>
        ///  Test for Whether InValid Name and InValid Password Are linked and exists to User
        /// </summary>
        [Test]
        public void isCorrectPassword_InValidName_InValidPassword_Should_Return_False()
        {
            // ------------------------- Arrange -------------------------
            //create invalid username and password 
            string invalidName = "008998832";
            string invalidPassword = "vDEkwE";

            // ------------------------- Act -------------------------
            // Fetch Result From Act
            bool result = TestHelper.UserService.IsCorrectPassword(invalidName, invalidPassword);

            // Reset
            // -------------------------  Assert -------------------------
            //check that result is incorrect combo 
            Assert.AreEqual(false, result);
        }

        /// <summary>
        ///  Test for Whether Valid Name and InValid Password Are linked and exists to User
        /// </summary>
        [Test]
        public void isCorrectPassword_ValidName_InValidPassword_Should_Return_False()
        {
            // ------------------------- Arrange -------------------------
            //create valid username
            string userName = "calif32";

            //invalid password 
            string invalidPassword = "613841";

            // ------------------------- Act -------------------------
            //fetch result 
            bool result = TestHelper.UserService.IsCorrectPassword(userName, invalidPassword);

            // Reset

            // ------------------------- Assert -------------------------
            // Invalid Passowrd
            Assert.AreEqual(false, result);
        }

        #endregion isCorrectPassword

        #region CreateData

        /// <summary>
        /// Test For Creating User 
        /// </summary>
        [Test]
        public void CreateData_New_UserModel_Should_Return_UserModel()
        {
            // ------------------------- Arrange -------------------------
            //create new usermodel 
            UserModel newUser = new UserModel()
            {
                //username
                Username = "Kitchen",
                //email
                Email = "KitchenNightMare@gmail.com",
                //password
                Password = "kitchepassword",
                //location 
                Location = "Cuba"
            };

            // ------------------------- Act -------------------------
            // Fetch User Result from Act
            UserModel userModel = TestHelper.UserService.CreateData(newUser);

            // Reset
            // ------------------------- Assert -------------------------
            //check username 
            Assert.AreEqual(true, userModel.Username.Equals(newUser.Username));

            //check email 
            Assert.AreEqual(true, userModel.Email.Equals(newUser.Email));

            //check password 
            Assert.AreEqual(true, userModel.Password.Equals(newUser.Password));

            //check location 
            Assert.AreEqual(true, userModel.Location.Equals(newUser.Location));
        }

        #endregion CreateData

        #region DeleteData

        /// <summary>
        /// Test for Deleting Profile with ValidID
        /// </summary>
        [Test]
        public void DeleteData_ValidId_Should_Return_True()
        {
            // ------------------------- Arrange -------------------------
            //use existing valid user id 
            int validId = 341292;

            // ------------------------- Act -------------------------
            // Fetch  Result from Act
            bool getResult = TestHelper.UserService.DeleteData(validId);

            // Reset
            // ------------------------- Assert -------------------------
            //check that data is deleted 
            Assert.AreEqual(true, getResult);

        }

        /// <summary>
        /// Test for Deleting Profile with InValid ID
        /// </summary>
        [Test]
        public void DeleteData_InValidId_Should_Return_False()
        {
            // ------------------------- Arrange -------------------------
            //create invalid user id
            int invalidId = 111111;

            // ------------------------- Act -------------------------
            // Fetch  Result from Act
            bool getResult = TestHelper.UserService.DeleteData(invalidId);

            // Reset
            // ------------------------- Assert -------------------------
            //check that data is not deleted because data does not exist 
            Assert.AreEqual(false, getResult);
        }

        #endregion DeleteData

        #region ToString

        /// <summary>
        /// Test for ToString
        /// </summary>
        [Test]
        public void ToString_Should_Return_Valid_Info()
        {
            // ------------------------- Arrange -------------------------
            //use valid exisitng user id 
            int validId = 491376;

            // ------------------------- Act -------------------------
            // Fetch User Result from Act
            UserModel userModel = TestHelper.UserService.GetUser(validId);
            //fetch result from usermodel 
            string correctResult = JsonSerializer.Serialize<UserModel>(userModel);
            // Reset
            // ------------------------- Assert -------------------------
            //check id is valid 
            Assert.AreEqual(true, userModel.UserID.Equals(validId));

            //check username 
            Assert.AreEqual(true, userModel.Username.Equals("calif32"));

            //check location 
            Assert.AreEqual(true, userModel.Location.Equals("United States of America"));

            //check tostring prints usermodel correctly 
            Assert.AreEqual(true, userModel.ToString().Equals(correctResult));

        }

        #endregion ToString

        #region CreateCookie

        /// <summary>
        /// Test for Creating Cookie With Valid Key and Valid Value
        /// </summary>
        [Test]
        public void CreateCookie_ValidKey_ValidValue_Should_AddCookie()
        {
            // ------------------------- Arrange -------------------------
            //create key and value to test cookie 
            string key = "testName";
            string value = "testkey";

            // ------------------------- Act -------------------------
            // Fetch  Result from Act
            bool result = TestHelper.UserService.CreateCookie(key, value);
            // ------------------------- Reset -------------------------

            // ------------------------- Assert -------------------------
            //check cookie was created 
            Assert.AreEqual(true, result);
            //test that key is correct 
            Assert.AreEqual("testkey", TestHelper.UserService.GetCookieValue(key));

        }

        /// <summary>
        /// Test For Creating Cookie with Key that Already Exists
        /// </summary>
        [Test]
        public void CreateCookie_KeyExist_Should_Return_False()
        {
            // ------------------------- Arrange -------------------------
            //create duplicate key and value 
            string key = "duplicateKey";
            string value = "duplicateValue";
            // Create Cookie in advance
            TestHelper.UserService.CreateCookie(key, value);

            // ------------------------- Act -------------------------
            // Fetch  Result from Act
            bool result = TestHelper.UserService.CreateCookie(key, value);

            // ------------------------- Reset -------------------------

            // ------------------------- Assert -------------------------
            //check that duplicate cookie could not be made 
            Assert.AreEqual(false, result);
        }

        #endregion CreateCookie

        #region GetCookieValue

        /// <summary>
        /// Test for Getting Cookie Value with Valid Cookie Key
        /// </summary>
        [Test]
        public void GetCookieValue_ValidKey_Should_Return_CookieValue()
        {
            // ------------------------- Arrange -------------------------
            //create key and value for cookie 
            string key = "newkey";
            string value = "newValue";

            // Create Cookie in advance
            TestHelper.UserService.CreateCookie(key, value);

            // ------------------------- Act -------------------------
            // Fetch Result from Act
            string result = TestHelper.UserService.GetCookieValue(key);

            // Reset

            // ------------------------- Assert -------------------------
            //check that Get Cookie produced correct result 
            Assert.AreEqual("newValue", result);
        }

        /// <summary>
        /// Test for Getting Cookie with InValid Key
        /// </summary>
        [Test]
        public void GetCookieValue_InValidKey_Should_Return_Null()
        {
            // ------------------------- Arrange -------------------------
            string key = "newkey";
            string value = "newValue";
            // Invalid key attribute
            string invalidKey = "fakekey";
            // Create Cookie in advance
            TestHelper.UserService.CreateCookie(key, value);

            // ------------------------- Act -------------------------
            // Fetch Result from Act
            string result = TestHelper.UserService.GetCookieValue(invalidKey);

            // Reset
            // ------------------------- Assert -------------------------
            //check return result is null 
            Assert.AreEqual(null, result);
        }

        #endregion GetCookieValue

        #region DeleteCookie

        /// <summary>
        /// Test for Deleting Cookie with Valid Key
        /// </summary>
        [Test]
        public void DeleteCookie_ValidKey_Should_Return_True()
        {
            // ------------------------- Arrange -------------------------
            //create key and value for cookie 
            string key = "deletekey";
            string value = "deleteValue";

            // Create Cookie in advance
            TestHelper.UserService.CreateCookie(key, value);

            // Act
            // Fetch Result from Act
            bool result = TestHelper.UserService.DeleteCookie(key);

            // ------------------------- Reset -------------------------

            // ------------------------- Assert -------------------------
            //check return result is true 
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Test For Deleting Cookie with Invalid Key
        /// </summary>
        [Test]
        public void DeleteCookie_InValidKey_Should_Return_True()
        {
            // ------------------------- Arrange -------------------------
            //create key and value for cookie 
            string key = "deletekey";
            string value = "deleteValue";

            string invalidKey = "fdjfdfd";

            // Create Cookie in advance
            TestHelper.UserService.CreateCookie(key, value);

            // ------------------------- Act -------------------------
            // Fetch Result from Act
            bool result = TestHelper.UserService.DeleteCookie(invalidKey);

            // Reset

            // -------------------------  Assert -------------------------
            //check return result is false
            Assert.AreEqual(false, result);
        }

        #endregion DeleteCookie
    }
}
