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
            if (UserLoginInput.Username != null || UserLoginInput.Password != null)
            {
                //set inputverified to false 
                bool InputVerified = false;

                //check if pass is correct
                InputVerified = UserService.IsCorrectPassword(UserLoginInput.Username, UserLoginInput.Password);

                if (InputVerified)
                {
                    //create cookie with username 
                    //UserService.CreateCookie("nameCookie", UserLoginInput.Username);

                    //Response.Cookies.Append("nameCookie", UserLoginInput.username); // Cookies Creation -- Edwin
                    return RedirectToPage("Login_Welcome", UserLoginInput.Username);
                 }

                 
                    //message incorrect password
                    Msg = "Invalid Username or Password";

                    //redirect to page 
                    return Page();
                  
            }

            //null input exists 
            Msg = "No Empty Entry";

            //redirect to page 
            return Page();
        }
    }
}