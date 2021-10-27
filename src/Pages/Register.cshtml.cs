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
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
           int userID = Convert.ToInt32(id);
            BindUser = UserService.GetUsers().FirstOrDefault(m => m.userID.Equals(userID));
        }

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


            //use regular expression to check if username contains only number or letters
            if (!usernameRg.IsMatch(BindUser.username))
            {
                return Page();
            }
            

            UserService.CreateData(BindUser);
            Response.Cookies.Append("nameCookie", BindUser.username);

            return RedirectToPage("./Index");
        }


    }
}
