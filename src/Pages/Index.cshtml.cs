using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;


namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Index model for the front page where some polls will be displayed
    /// and other links to CRUDI operations for user 
    /// </summary>
    public class IndexModel : PageModel
    {
        //create log category for IndexModel  
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Poll Services
        /// </summary>
        public JsonFilePollService PollServices { get; }

        /// <summary>
        /// User Services
        /// </summary>
        public JsonFileUserService UserService { get; }

        /// <summary>
        /// String to Hold Cookie Value acquired from User Services
        /// </summary>
        public string CookieNameValue { get; set; }

        /// <summary>
        /// List of Polls
        /// </summary>
        public IEnumerable<PollModel> PollModels { get; set; }

        /// <summary>
        /// Message To Display 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///  Initalize logger obeject and add productServices
        ///  Soon to be changed to polls 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="jsonFilePollService"></param>
        /// <param name="jsonFileUser"></param>
        public IndexModel(ILogger<IndexModel> logger, JsonFilePollService jsonFilePollService, JsonFileUserService jsonFileUser)
        {
            _logger = logger;
            PollServices = jsonFilePollService;
            UserService = jsonFileUser;

            // Message attribute
            Message = "Must Be Logged In To Create Poll";
            // Initialize attribute CookieNameValue
            CookieNameValue = UserService.GetCookieValue("nameCookie");
        }      

        /// <summary>
        /// initializes a list of all
        /// </summary>
        public void OnGet()
        {
            PollModels = PollServices.GetPolls();
        }

    }
}