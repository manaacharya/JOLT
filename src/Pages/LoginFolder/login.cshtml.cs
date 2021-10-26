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


        private readonly ILogger<LoginPageModel> _logger;
        public LoginPageModel(ILogger<LoginPageModel> logger,
            JsonFileUserService userService)
        {
            _logger = logger;
            UserService = userService;
        }


        public JsonFileUserService UserService { get; }
        public IEnumerable<UserModel> UserList { get; private set; } // list of users


        public void OnGet() => UserList = UserService.GetUsers(); //initialize UserList

        public string Msg { get; set; } // A message for user to see

        [BindProperty]
        public Models.UserLoginModel UserInput_test { get; set; } // helper class for user input

        
        /// <summary>
        ///  If user is valid, direct to login_welcome page; if not, display message to instruct users
        /// </summary>
        /// <param id> user id to verify</param>
        public IActionResult OnPost(string id)
        {

            if (UserInput_test.username != null && UserInput_test.password != null)
            {
                bool InputVerified = false;
                try
                {
                    InputVerified = UserService.isCorrectPassword(UserInput_test.username, UserInput_test.password);
                    if (InputVerified)
                    {
                        Response.Cookies.Append("nameCookie", UserInput_test.username); // Cookies Creation -- Edwin
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

            Msg = "No Empty Entry";
            return Page();
            
        }
    }
}
