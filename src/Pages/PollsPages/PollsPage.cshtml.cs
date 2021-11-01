using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    public class PollsPageModel : PageModel
    {
        // logger logs the information ex system info, error
        private readonly ILogger<PollsPageModel> _logger;

        /// <summary>
        /// initializes the logger and userService
        /// </summary>
        /// <param name="logger"></param>
        public PollsPageModel(ILogger<PollsPageModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// OnGet information dispalyed
        /// TODO: add PollServices polls to display polls
        /// </summary>
        /*
        public void OnGet()
        {
        }
        */

        public IActionResult OnPostGuidelines()
        {
            return Redirect("/PollsPage/GuidelinePage");
        }
    }
}
