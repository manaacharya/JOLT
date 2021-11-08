using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// PollPage model for displaying polls
    /// </summary>
    public class PollsPageModel : PageModel
    {
        // logger logs the information ex system info, error
        private readonly ILogger<PollsPageModel> _logger;

        /// <summary>
        /// Poll Services
        /// </summary>
        public JsonFilePollService PollServices { get;  }

        /// <summary>
        /// List of Polls
        /// </summary>
        public IEnumerable<PollModel> Polls { get; set; }

        /// <summary>
        /// initializes the logger and pollService
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="pollService"></param>
        public PollsPageModel(ILogger<PollsPageModel> logger,
            JsonFilePollService pollService)
        {
            _logger = logger;

            //Pollservice object 
            PollServices = pollService;
        }

        /// <summary>
        /// initializes a list of all
        /// </summary>
        public void OnGet()
        {
            Polls = PollServices.GetPolls();
        }

        /// <summary>
        /// Takes user to guideline page when button is clicked
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostGuidelines()
        {
            return Redirect("/PollsPage/GuidelinePage");
        }
    }
}
