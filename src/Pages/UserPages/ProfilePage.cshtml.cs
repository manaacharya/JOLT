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
    /// 
    /// </summary>
    public class ProfilePageModel : PageModel
    {
        /// <summary>
        /// Message method for update and delete methods
        /// used to confirm method is successful 
        /// </summary>
        public string Message { get; set; }

        //log category for ProfilePageModel 
        private readonly ILogger<ProfilePageModel> _logger;

        /// <summary>
        /// JsonFileUserService for to get and set userservices 
        /// </summary>
        public JsonFileUserService UserServices { get; set; }

        /// <summary>
        /// get and set usermodel 
        /// </summary>
        public UserModel UserModel  { get; set; }

        /// <summary>
        /// get and set updateusermodel 
        /// </summary>
        [BindProperty]
        public UpdateUserModel UpdateUser { get; set; }

        /// <summary>
        /// initialize logger 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userService"></param>
        public ProfilePageModel(ILogger<ProfilePageModel> logger,
            JsonFileUserService userService)
        {
           
            _logger = logger;

            //create userService object 
            UserServices = userService;
        }

        /// <summary>
        /// OnGet, the cookie stores user information 
        /// </summary>
        public void OnGet()
        {
            //cookie username 
            var cookieValue = Request.Cookies["nameCookie"];
            //userModel object of cookie username stored 
            UserModel = UserServices.GetUser(cookieValue.ToString());
        }
        
        /// <summary>
        /// After, username is updated to new username, password, email
        /// and location 
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (UpdateUser == null)
            {
                //back to profile page 
                return RedirectToPage("ProfilePage");
            }

            //userservice object 
            var updateStatus = UserServices.UpdateProfile(UpdateUser);

            if (updateStatus == null)
            {
                // Error Updating User
                Message = $"Error Updating {UpdateUser.UpdateName}";

                return RedirectToPage("ProfilePage");
            }

            // Updated Cookie To User Name
            Response.Cookies.Delete("nameCookie");

            //cookie username updated to new update 
            Response.Cookies.Append("nameCookie", UpdateUser.UpdateName);

            //Message to confirm update is successful 
            Message = $"Update Successful to {UpdateUser.UpdateID}, Name: {UpdateUser.UpdateName}";

            //redirect back to profile page 
            return RedirectToPage("ProfilePage");
        }

        /// <summary>
        /// delete the user that's currently logged in, and direct to home page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnPostDeleteProfile(int id)
        {
            //result of userID using userservices 
            bool result = UserServices.DeleteData(id);

            if(result == false)
            {
                //message to confirm user deleted 
                Message = $"User Not Deleted";

                //return back to profilepage 
                return RedirectToPage("ProfilePage"); 
            }

            //message to confirm user is deleted 
            Message = $"User deleted.";

            //Delete cookie
            Response.Cookies.Delete("nameCookie");
            return Redirect("/Index"); //RedirectToPage("/Pages/Index");
            //RedirectToPage("./Index");


        }
              
    }


}
