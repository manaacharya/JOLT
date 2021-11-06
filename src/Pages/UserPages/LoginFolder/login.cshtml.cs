using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class LoginPageModel : PageModel
    {
        // logger logs the information ex system info, error 
        private readonly ILogger<LoginPageModel> _logger;

        /// <summary>
        /// initializes the logger and userService
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userService"></param> 
        public LoginPageModel(ILogger<LoginPageModel> logger,
            JsonFileUserService userService)
        {
            _logger = logger;

            //Userservice object
            UserService = userService;
        }

        // Utility for JasonFile
        public JsonFileUserService UserService { get; }

        /// <summary>
        /// A message for user to see
        /// </summary>
        public string Msg { get; set; } 

        /// <summary>
        /// helper class for user input
        /// </summary>
        [BindProperty]
        public Models.UserLoginModel UserInput_test { get; set; }

        
        /// <summary>
        ///  If user is valid, direct to login_welcome page; if not, display message to instruct users
        /// </summary>
        public IActionResult OnPost()
        {

            if (UserInput_test.Username != null && UserInput_test.Password != null)
            {
                //set inputverified to false 
                bool InputVerified = false;

                InputVerified = UserService.IsCorrectPassword(UserInput_test.Username, UserInput_test.Password);

                if (InputVerified)
                {
                    //create cookie with username 
                    UserService.CreateCookie("nameCookie", UserInput_test.Username);

                    //Response.Cookies.Append("nameCookie", UserInput_test.username); // Cookies Creation -- Edwin
                    return RedirectToPage("Login_Welcome");
                 }

                 else
                 {
                    //message incorrect password
                    Msg = "Invalid Username or Password";

                    //redirect to page 
                    return Page();
                  }
            }

            //null input exists 
            Msg = "No Empty Entry";

            //redirect to page 
            return Page();
        }
    }
}
