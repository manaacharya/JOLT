using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Privacy page to display our privacy policy 
    /// </summary>
    public class PrivacyModel : PageModel
    {
        //creates log category PrivacyModel 
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Initializes logger 
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// On get method - empty 
        /// </summary>
        public void OnGet()
        {
        }
    }
}
