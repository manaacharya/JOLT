using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// initialize the logger object
        /// </summary>
        /// <param name="logger"></param> logger object
        public AboutUsModel(ILogger<AboutUsModel> logger)
        {
            _logger = logger;
        }

        /// <summary> 
        /// This is a dummy method for now
        /// </summary>
        public void OnGet()
        {
        }
    }
}
