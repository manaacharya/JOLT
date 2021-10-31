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
            UserService = userService;
        }

        // Utility for JasonFile
        public JsonFileUserService UserService { get; }

        // public IEnumerable<UserModel> UserList { get; private set; } // list of users
        // public void OnGet() => UserList = UserService.GetUsers(); //initialize UserList

        public string Msg { get; set; } // A message for user to see

        [BindProperty]
        public Models.UserLoginModel UserInput_test { get; set; } // helper class for user input

        
        /// <summary>
        ///  If user is valid, direct to login_welcome page; if not, display message to instruct users
        /// </summary>
        public IActionResult OnPost()
        {

            if (UserInput_test.Username != null && UserInput_test.Password != null)
            {
                bool InputVerified = false;
                try
                {
                    InputVerified = UserService.IsCorrectPassword(UserInput_test.Username, UserInput_test.Password);
                    if (InputVerified)
                    {
                        UserService.CreateCookie("nameCookie", UserInput_test.Username);
                        //Response.Cookies.Append("nameCookie", UserInput_test.username); // Cookies Creation -- Edwin
                        return RedirectToPage("Login_Welcome");
                    }
                    else
                    {
                        // incorrect password
                        Msg = "Invalid Username or Password";
                        return Page();
                    }

                }
                catch
                {
                    // username does not exist
                    Msg = "Invalid Username or Password";
                    return Page();
                }

            }
            Msg = "No Empty Entry"; // null input exists
            return Page();
            
        }
    }
}
