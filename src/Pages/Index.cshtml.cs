using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        /// Initalize logger obeject and add productServices
        /// Soon to be changed to polls 
        /// </summary>
        /// <param name="logger"></param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        /// <summary>
      

        /// <summary>
        /// initializes a list of all
        /// </summary>
        public IActionResult OnGet()
        {

            return RedirectToPage("./PollsPages/IndexPollsPage");

        }

    }
}