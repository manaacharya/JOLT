using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Methods for profile page 
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
        /// JsonFileUserService for to get and set user services 
        /// </summary>
        public JsonFileUserService UserServices { get; set; }


        /// <summary>
        /// get and set update user model 
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
            //set logger
            _logger = logger;

            //create userService object 
            UserServices = userService;
        }

        /// <summary>
        /// OnGet, the cookie stores user information 
        /// </summary>
        public void OnGet()
        {
        }
        
        /// <summary>
        /// After, user name is updated to new user name, password, email
        /// and location 
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {

            if (UpdateUser == null)
            {

                //Back to Index page 
                return RedirectToPage("/Index");

            }

            //user service object 
            var updateStatus = UserServices.UpdateProfile(UpdateUser);

            if (updateStatus == null)
            {

                // Error Updating User
                Message = $"Error Updating {UpdateUser.UpdateName}";

                //return to page
                return Page(); //RedirectToPage("ProfilePage");

            }

            //Message to confirm update is successful 
            Message = $"Update Successful to {UpdateUser.UpdateID}, Name: {UpdateUser.UpdateName}";

            //redirect back to profile page 
            return RedirectToPage("ProfilePage", UpdateUser.UpdateName);
        }

        /// <summary>
        /// delete the user that's currently logged in, and direct to home page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnPostDeleteProfile(int id)
        {
            //result of userID using user services 
            bool result = UserServices.DeleteData(id);

            if(result == false)
            {
                //message to confirm user deleted 
                Message = $"User Not Deleted";

                //return back to profile page 
                return RedirectToPage("ProfilePage"); 
            }

            //message to confirm user is deleted 
            Message = $"User deleted.";

            //return to page
            return RedirectToPage("/Index", "removeCookie"); 
        }
    }
}