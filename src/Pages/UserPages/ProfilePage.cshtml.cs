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

        public UserModel UserModel  { get; set; }
       
        [BindProperty]
        public UpdateUserModel UpdateUser { get; set; }

        public ProfilePageModel(ILogger<ProfilePageModel> logger,
            JsonFileUserService userService)
        {
           
            _logger = logger;
            UserServices = userService;
        }
        
        public void OnGet()
        {
            var cookieValue = Request.Cookies["nameCookie"];
            UserModel = UserServices.GetUser(cookieValue.ToString());
        }
        
        // Update the user's information with new entires
        public IActionResult OnPost()
        {
            if (UpdateUser == null)
            {
                return RedirectToPage("ProfilePage");
            }

            var updateStatus = UserServices.UpdateProfile(UpdateUser);

            if (updateStatus == null)
            {
                // Error Updating User
                Message = $"Error Updating {UpdateUser.UpdateName}";

                return RedirectToPage("ProfilePage");
            }

            // Updated Cookie To User Name
            Response.Cookies.Delete("nameCookie");
            Response.Cookies.Append("nameCookie", UpdateUser.UpdateName);

            Message = $"Update Successful to {UpdateUser.UpdateID}, Name: {UpdateUser.UpdateName}";

            return RedirectToPage("ProfilePage");
        }


        // delete the user that's currently logged in, and direct to home page
        public IActionResult OnPostDeleteProfile(int id)
        {
            bool result = UserServices.DeleteData(id);

            if(result == false)
            {
                Message = $"User Not Deleted";

                return RedirectToPage("ProfilePage");
            }


            Message = $"User deleted.";

            //Delete cookie
            Response.Cookies.Delete("nameCookie");
            return Redirect("/Index"); //RedirectToPage("/Pages/Index"); //RedirectToPage("./Index");


        }
              
    }


}
