using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    public class ProfilePageModel : PageModel
    {
        private readonly ILogger<ProfilePageModel> _logger;

        // User Services
        public JsonFileUserService UserServices { get; set; }
        // List of Users
        public IEnumerable<UserModel> Users { get; set; }
        // A User, Can be Modified
        public UserModel User { get; set; }


        // User Attributes For Updates
       // public string GUserName { get; set; }
       // public string GUserPassword { get; set; }
       // public string GUserEmail { get; set; }
        //public string GUserLocation { get; set; }



        public ProfilePageModel(ILogger<ProfilePageModel> logger,
            JsonFileUserService userService)
        {
            _logger = logger;
            UserServices = userService;
        }
        public void OnGet()
        {
            Users = UserServices.GetUsers();
            //User = UserServices.GetUser()
        }

    }
}
