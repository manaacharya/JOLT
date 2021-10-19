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

        public string Message { get; set; }

        private readonly ILogger<ProfilePageModel> _logger;

        // User Services
        public JsonFileUserService UserServices { get; set; }
        // List of Users
        public IEnumerable<UserModel> Users { get; set; }
        // A User, Can be Modified
       // public UserModel UserModel { get; set; }

        public UserModel UserModel { get; set; }

        [BindProperty]
        public UpdateUserModel UpdateUser { get; set; }

        public ProfilePageModel(ILogger<ProfilePageModel> logger,
            JsonFileUserService userService)
        {
           
            _logger = logger;
            UserServices = userService;
        }
        
        //public void OnGet()

        public IActionResult OnPost()
        {
            UserServices.UpdateProfile(UpdateUser);

            // Updated Cookie To User Name
            Response.Cookies.Delete("nameCookie");

            Response.Cookies.Append("nameCookie", UpdateUser.UpdateName);

            Message = $"Update Successful to {UpdateUser.UpdateID}, Name: {UpdateUser.UpdateName}";

            return RedirectToPage("ProfilePage");
        }

        public IActionResult OnPostDeleteProfile()
        {
            UserServices.DeleteData(UserModel);
            Message = $"User deleted.";
            //delete cookie
            Response.Cookies.Delete("nameCookie"); 
                return RedirectToPage("Register");


        }

       /* public void OnPostUpdateUser()
        {
            // Message = $"Update {UpdateUser.UpdateID}, {UpdateUser.UpdateName}, Location: {UpdateUser.UpdateLocation} ";
            // Message = $"Update {Request.QueryString["name"]} to {updateUser.location}";
            UserServices.UpdateProfile(UpdateUser);// updates

            // Updated Cookie To User Name
            Response.Cookies.Delete("nameCookie");
            Response.Cookies.Append("nameCookie", UpdateUser.UpdateName);
            Message = $"Update Successful to {UpdateUser.UpdateID}, Name: {UpdateUser.UpdateName}";
        }*/


    }


}
