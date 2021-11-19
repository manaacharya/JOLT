using System.Text.RegularExpressions;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Page to register users and add them into the users.json database 
    /// </summary>
    public class RegisterModel : PageModel
    {
        //log category RegisterModel 
        private readonly ILogger<RegisterModel> _logger;


        /// <summary>
        /// Data middletier
        /// </summary>
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

            //userservice object 
            UserService = userService;
        }

        /// <summary>
        /// Usermodel object BindUser  
        /// </summary>
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
            if (usernameRg.IsMatch(BindUser.Username) == false)
            {
                return Page();
            }

            //check if password length is less than 6
            if (BindUser.Password.Length < 6)
            {
                return Page();
            }

            //check if email is not valid
            if (emailRg.IsMatch(BindUser.Email) == false)
            {
                return Page();
            }

            //check if location is not valid
            if (locationRg.IsMatch(BindUser.Location) == false)
            {
                return Page();
            }

            // Check whether User Already Exists
            var getUser = UserService.GetUser(BindUser.Username);

            if(getUser != null)
            {
                // Redirect to Log In. If User with the same Name Alreay Exists
                return RedirectToPage("./LoginFolder/login");
            }

            //create User using User Information 
            UserModel userModel =  UserService.CreateData(BindUser);

            if(userModel == null)
            {
                // Something Went Wrong With Registration Service to Create User
                return Page();
            }

            // Redirect to Login Welcome
            return RedirectToPage("./LoginFolder/Login_Welcome", userModel.Username);
        }
    }
}