using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// This is the login model for loggin in
    /// </summary>
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
            //set logger
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
        public Models.UserLoginModel UserLoginInput { get; set; }

        
        /// <summary>
        ///  If user is valid, direct to login_welcome page; if not, display message to instruct users
        /// </summary>
        public IActionResult OnPost()
        {
            if (UserLoginInput.Username == null || UserLoginInput.Password == null)
            {
                // null input exists 
                Msg = "No Empty Entry";
                // redirect to the same page 
                return Page();
            }

            // set inputverified to false 
            bool InputVerified = false;
            // verify the input
            InputVerified = UserService.IsCorrectPassword
                (UserLoginInput.Username, UserLoginInput.Password);

            if (!InputVerified)
            {
                //message incorrect password
                Msg = "Invalid Username or Password";
                //redirect to the same page 
                return Page();
            }
            //Response.Cookies.Append("nameCookie", UserLoginInput.username); // Cookies Creation -- Edwin
            return RedirectToPage("Login_Welcome", UserLoginInput.Username);
        }
    }
}