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

        // WebHostEnvironment knows where the  
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
    }
}