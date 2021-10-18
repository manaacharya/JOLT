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
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<UserModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
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
            // Return A Specific User using Name
            try
            {
                return GetUsers().First(x => x.username == name);
            } catch
            {
                //FX: NOT very usful so far
                return null; 
            }
            
        }

        /// FX: Get the password of a user(given an user entry is found)

        public string GetPassWord(string name)
        {
            if (GetUser(name) == null) return "BAD_PASSWORD";
            return GetUser(name).password;
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
        public UserModel CreateData()
        {
            Random rnd = new Random();
            var data = new UserModel()
            {
                userID = rnd.Next(1, 999999), //generate a random number between 1 and 999999 to be 6 digits
                username = "Enter a username",
                password = "Enter a password",
                email = "Enter an email",
                location = "Enter a location",
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
        public UserModel UpdateData(UserModel data)
        {
            var users = GetUsers();
            var userData = users.FirstOrDefault(x => x.userID.Equals(data.userID));
            if (userData == null)
            {
                return null;
            }

            userData.username = data.username;
            userData.email = data.email;
            userData.password = data.password;
            userData.location = data.location;

            SaveData(users);

            return userData;
        }
        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public UserModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetUsers();
            var data = dataSet.FirstOrDefault(m => m.userID.Equals(id));

            var newDataSet = GetUsers().Where(m => m.userID.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }
    }
}