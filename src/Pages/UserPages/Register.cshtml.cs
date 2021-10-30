using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace ContosoCrafts.WebSite.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;


        // Data middletier
        public JsonFileUserService UserService { get; set; }
        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userService"></param>
        // The data to show, bind to it for the post
        public RegisterModel(ILogger<RegisterModel> logger, JsonFileUserService userService)
        {
            _logger = logger;
            UserService = userService;
        }
        [BindProperty]
        public UserModel BindUser{ get; set; }


        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable User
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            // Create a Regex for checking if username contains only number or letters
            Regex usernameRg = new Regex(@"^[a-zA-Z0-9]+$");

            // Create a Regex for checking valid email format
            Regex emailRg = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            // Create a Regex for checking that only letters are in string
            Regex locationRg = new Regex(@"^[a-zA-Z' ']+$");


            //use regular expression to check if username contains only number or letters
            if (usernameRg.IsMatch(BindUser.username) == false)
            {

                return Page();
            }

            //check if password length is less than 6
            if (BindUser.password.Length < 6)
            {
                return Page();
            }

            //check if email is not valid
            if (emailRg.IsMatch(BindUser.email) == false)
            {
                return Page();
            }

            //check if location is not valid
            if (locationRg.IsMatch(BindUser.location) == false)
            {
                return Page();
            }


            UserService.CreateData(BindUser);
            Response.Cookies.Append("nameCookie", BindUser.username);

            return RedirectToPage("./ProfilePage");
        }


    }
}
