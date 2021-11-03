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
        /// Takes user to guideline page when button is clicked
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostGuidelines()
        {
            return Redirect("/PollsPage/GuidelinePage");
        }
    }
}
