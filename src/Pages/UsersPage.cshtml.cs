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
    public class UsersPageModel : PageModel
    {
        private readonly ILogger<UsersPageModel> _logger;

        // User Services
        public JsonFileUserService UserServices { get; set; }
        // List of Users
        public IEnumerable<UserModel> Users { get; set; }
        // A User, Can be Modified
      
        public UsersPageModel(ILogger<UsersPageModel> logger,
            JsonFileUserService userService)
        {
           
            _logger = logger;
            UserServices = userService;
        }
        
        // initializes a list of all 
        public void OnGet()
        {
            Users = UserServices.GetUsers();
        }
   
     }


}
