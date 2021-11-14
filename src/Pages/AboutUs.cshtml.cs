using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// About page using page model to create a page where we have information
    /// about our website and the creators 
    /// </summary>
    public class AboutUsModel : PageModel
    {  

        // create log category of AboutUsModel 
        private readonly ILogger<AboutUsModel> _logger;

    }

}