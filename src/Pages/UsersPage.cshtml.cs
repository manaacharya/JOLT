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
    /// <summary>
    /// UserPage model for displaying users 
    /// </summary>
    public class UsersPageModel : PageModel
    {
        //log category for UsersPageModel 
        private readonly ILogger<UsersPageModel> _logger;


        /// <summary>
        /// User Services
        /// </summary>
        public JsonFileUserService UserServices { get; set; }
        
        /// <summary>
        /// List of Users
        /// </summary>
        public IEnumerable<UserModel> Users { get; set; }

        /// <summary>
        /// A User, Can be Modified
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userService"></param>
        public UsersPageModel(ILogger<UsersPageModel> logger,
            JsonFileUserService userService)
        {
           
            _logger = logger;

            //Userservice object 
            UserServices = userService;
        }
      
        /// <summary>
        /// initializes a list of all
        /// </summary>
        public void OnGet()
        {
            Users = UserServices.GetUsers();
        }
   
     }

}
