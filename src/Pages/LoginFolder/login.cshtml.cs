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
    public class LoginModel : PageModel
    {


        private readonly ILogger<IndexModel> _logger;
        public LoginModel(ILogger<IndexModel> logger,
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
        public Models.LoginModel UserInput_test { get; set; } // helper class for user input

        
        /// <summary>
        ///  If user is valid, direct to login_welcome page; if not, display message to instruct users
        /// </summary>
        /// <param id> user id to verify</param>
        public IActionResult OnPost(string id)
        {
            string correct_password = UserService.GetPassWord(UserInput_test.username);
            if (UserInput_test.username != null && UserInput_test.password != null) { 
               if (UserInput_test.password.Equals(correct_password)) {
                    // Cookies Creation -- Edwin 
                    Response.Cookies.Append("nameCookie", UserInput_test.username); 
                    return RedirectToPage("Login_Welcome");
                }
                else 
                {
                    Msg = "Invalid Username or Password";
                    return Page();
                }
            } else
            {
                Msg = "No Empty Entry";
                return Page();
            }
        }
    }
}
