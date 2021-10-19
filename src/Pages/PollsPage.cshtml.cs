using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class PollsPageModel : PageModel
    {
        private readonly ILogger<PollsPageModel> _logger;

        public PollsPageModel(ILogger<PollsPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
