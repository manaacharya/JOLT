using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// JsonFileUserService with Services for User
    /// </summary>
    public class JsonFileUserService
    {

        /// <summary>
        /// Constructor For JsonFileUserService 
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// WebHostEnvironment knows where the  data file is stored at
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// specify file path to retrieve from
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath,
                "data", "users.json"); }
        }

        /// <summary>
        ///  Deserialize a Json of User to List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserModel> GetUsers()
        {
            //create file reader for Json file 
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {

                // Deserialize Json to List
              return JsonSerializer.Deserialize<UserModel[]>
                    (jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        //make case insensitive
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Save All users data to storage
        /// </summary>
        /// <param name="users"></param>
        private void SaveData(IEnumerable<UserModel> users)
        {
            using (var outputStream = File.Create(JsonFileName))
            {
                // Serialize Collection to Json
                JsonSerializer.Serialize<IEnumerable<UserModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        //skip validation 
                        SkipValidation = true,

                        //make indented 
                        Indented = true
                    }),
                    //for users
                    users
                );
            }
        }


        /// <summary>
        ///  Service To Update a User Account
        /// </summary>
        /// <param name="updateuser"></param>
        public UserModel UpdateProfile(UpdateUserModel updateUser)
        {
            UserModel userModel = GetUser(updateUser.UpdateID);

            if (userModel == null)
            {
                return null;
            }

            // Modify The User Object
            //username 
            userModel.Username = updateUser.UpdateName;

            //email
            userModel.Email = updateUser.UpdateEmail;

            //password
            userModel.Password = updateUser.UpdatePassword;

            //location 
            userModel.Location = updateUser.UpdateLocation;

            // Find User from DataSet and Overwrite

            List<UserModel> userModels = GetUsers().ToList();

            userModels.RemoveAll(x => x.UserID == userModel.UserID);
            userModels.Add(userModel);

            //save data into database 
            SaveData(userModels);

            return userModel;
        }


        /// <summary>
        /// Get A Specific User using the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUser(int id)
        {
            List<UserModel> getuserList = GetUsers().ToList();

            // Fetch User By ID
            var getUser = getuserList.Find(x => x.UserID == id);

            // Condition For User Existance
            if (getUser == null)
            {
                // User Doesn't Exist
                return null;
            }

            // Return User
            return getUser;
        }

        /// <summary>
        /// Get A Specific User using A Name. 
        /// Caution for Duplicate Name, the first duplicate is returned.
        /// FX: added try catch structure
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UserModel GetUser(string name)
        {
            // Fetch User By Name
            var getUser = GetUsers().ToList().Find(x => x.Username == name);

            // Condition For User Existance
            if (getUser == null)
            {
                // User Doesn't Exist
                return null;
            }
            // Return User
            return getUser;

        }

        /// <summary>
        /// Get the password of a user(given an user entry is found)
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>userpassword if the user eixst; null otherwise
        /// </returns>
        public string GetPassWord(string userName)
        {
            var getUser = GetUser(userName);

            // Condition For User Existance
            if (getUser == null)
            {
                // User Doesn't Exist
                return null;
            }

            // Return Password
            return getUser.Password;

        }

        /// <summary>
        /// Return true if username's correct password is password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>true if password is correct
        ///         false if password is incorrect or 
        ///         username does not exist
        /// </returns>
        public bool IsCorrectPassword(string userName, string userPassword)
        {
            // try
            //{
            // Fetch User
            var getUser = GetUser(userName);

            // Condition For User Existance
            if (getUser == null)
            {
                // User Doesn't Exist
                return false;
            }

            // Condition For Password Match
            if (getUser.Password != userPassword)
            {
                // Password Do not Match
                return false;
            }
            // Password Are Equal
            return true;

        }


        /// <summary>
        /// Create a new user using default values
        /// After create the user can update to set values
        /// </summary>
        /// <param name="user"></param>
        /// <returns>newly created data</returns>
        public UserModel CreateData(UserModel user)
        {
            // Random Instance Created
            Random rnD = new Random();

            // UserModel Defined with Random ID
            var data = new UserModel()
            {
                // generate a random number between 1 and 999999 to be 6 digits
                UserID = rnD.Next(1, 999999),

                Username = user.Username,

                Password = user.Password,

                Email = user.Email,

                Location = user.Location,
            };

            //object Getusers 
            var dataSet = GetUsers();

            // Add to Dataset
            dataSet = dataSet.Append(data);

            // Convert List into Json Dataset
            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <param name="id">true if sucess; otherwise false(when user id does not exist)</param>
        public bool DeleteData(int id)
        {
            // Get User By ID
            UserModel userModel = GetUser(id);
            // Check if User Exists NUll
            if (userModel == null)
            {
                return false;
            }

            // Get DataSet and Remove
            List<UserModel> userModels = GetUsers().ToList();

            // Remove UserModel
            userModels.RemoveAll(x => x.UserID == userModel.UserID);

            // Save List to Data Set
            SaveData(userModels);

            return true;
        }
    }
}