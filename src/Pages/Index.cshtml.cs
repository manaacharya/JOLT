using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
        /// Initalize logger obeject and add productServices
        /// Soon to be changed to polls 
        /// </summary>
        /// <param name="logger"></param>
        public IndexModel(ILogger<IndexModel> logger, JsonFilePollService pollService)
        {
            _logger = logger;
            PollServices = pollService;
        }
        /// <summary>
        /// Poll Services
        /// </summary>
        public JsonFilePollService PollServices { get; }

        /// <summary>
        /// List of Polls
        /// </summary>
        public IEnumerable<PollModel> Polls { get; set; }


        /// <summary>
        /// initializes a list of all
        /// </summary>
        public void OnGet()
        {
            Polls = PollServices.GetPolls();
        }

    }
}