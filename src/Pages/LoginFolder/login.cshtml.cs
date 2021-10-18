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
        public IEnumerable<UserModel> UserList { get; private set; }



        // public void OnGet() => UserList = UserService.GetUsers();
        // public void OnGet() {}

        public string Msg { get; set; }

        [BindProperty]
        public Models.LoginModel UserInput_test { get; set; }

        public IActionResult OnPost(string id)
        {
            if (UserInput_test.username.Equals("abc") && UserInput_test.password.Equals("123"))
            {
                
                HttpContext.Session.SetString("Username", UserInput_test.username);
                return RedirectToPage("Login_Welcome");
            }
            else
            {
                Msg = "Invalid Username or Password";
                return Page();
            }
        }

        public Boolean isValidUser()
        {
            return false;
        }

    }
}
