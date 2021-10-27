using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

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

        public void OnGet()
        {
        }
    }
}
