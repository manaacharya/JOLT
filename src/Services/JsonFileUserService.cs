using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    public class JsonFileUserService
    {
        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // WebHostEnvironment knows where the  data file is stored at
        public IWebHostEnvironment WebHostEnvironment { get; }

        // specify file path to retrieve from
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json"); }
        }

        public IEnumerable<UserModel> GetUsers()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<UserModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }


        /// <summary>
        ///  Service an Update To User Account
        /// </summary>
        /// <param name="updateuser"></param>
        public UserModel UpdateProfile(UpdateUserModel updateuser)
        {
            List<UserModel> update_users_list = GetUsers().ToList();

            // Get the Old User, By searching for The ID
            UserModel get_storedUser = update_users_list.Find(x => x.userID == updateuser.UpdateID); // GetUsers().First(x => x.userID == updateuser.UpdateID);

            if (get_storedUser == null)
            {
                // No Such User Exist
                return null;
            }

            // Remove Old Data From List
            update_users_list.Remove(get_storedUser);

            // Update/OverWrite the Previously Stored User
            get_storedUser.userID = updateuser.UpdateID;
            get_storedUser.username = updateuser.UpdateName;
            get_storedUser.email = updateuser.UpdateEmail;
            get_storedUser.password = updateuser.UpdatePassword;
            get_storedUser.location = updateuser.UpdateLocation;

            // Add This to GetUsers()
            update_users_list.Add(get_storedUser);    //GetUsers().ToList().Add(get_storedUser);

            // Write Back to Database
            SaveData(update_users_list);

            return get_storedUser;
        }


        /// <summary>
        /// Get A Specific User using the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUser(int id)
        {
            // Return A Specific User using ID
            return GetUsers().First(x => x.userID == id);
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
           return GetUsers().First(x => x.username == name);
              
        }

        /// FX: Get the password of a user(given an user entry is found)
        public string GetPassWord(string name)
        {
            try
            {
                return GetUser(name).password;

            } catch
            {
                throw new UsernameNotFoundException
                    ("Can't find the password due to non-existing username");
            }
        }
        
        /// <summary>
        /// return true if username's correct password is password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool isCorrectPassword(string username, string password)
        {
            try
            {

                return GetPassWord(username).Equals(password);

            }
            catch
            {
                throw new UsernameNotFoundException
                    ("Can't find the password due to non-existing username");
            }
        }
        /// <summary>
        /// Save All users data to storage
        /// </summary>
        private void SaveData(IEnumerable<UserModel> users)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<UserModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    users
                );
            }
        }

        /// <summary>
        /// Create a new user using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public UserModel CreateData(UserModel user)
        {
            Random rnd = new Random();
            var data = new UserModel()
            {
                userID = rnd.Next(1, 999999), //generate a random number between 1 and 999999 to be 6 digits
                username = user.username,
                password = user.password,
                email = user.email,
                location = user.location,
            };

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetUsers();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        /*public UserModel UpdateData(UserModel data)
        {
            Random rnd = new Random();

            var users = GetUsers();
            // Validation for No Existing User
            var userData = users.FirstOrDefault(x => x.userID.Equals(data.userID));
            if (userData == null)
            {
                return null;
            }
          //  userData.userID = rnd.Next(1, 999999);

            userData.username = data.username;
            userData.email = data.email;
            userData.password = data.password;
            userData.location = data.location;
            SaveData(users);

            return userData;
        }*/
        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public void DeleteData(int id)
        {
            // Get the current set, and append the new record to it
            //var dataSet = GetUsers();
            //var data = dataSet.FirstOrDefault(m => m.userID.Equals(id));

            //var newDataSet = GetUsers().Where(m => m.userID.Equals(id) == false);
            //UserModel userModel = new UserModel();

            List<UserModel> update_users_list = GetUsers().ToList();

            // Get the Old User, By searching for The ID
            UserModel get_storedUser = update_users_list.Find(x => x.userID == id); // GetUsers().First(x => x.userID == updateuser.UpdateID);

            // Remove Old Data From List
            update_users_list.Remove(get_storedUser);

            //convert list into Json
            SaveData(update_users_list);

        }



        /// <summary>
        /// Used to throw exception when username is not found 
        /// </summary>
        public class UsernameNotFoundException : Exception
        {
            public UsernameNotFoundException() { }

            public UsernameNotFoundException(string message) : base(message) { }

        }

    }
}