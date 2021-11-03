using System.Collections.Generic;

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
        /// Dispaly all products on OnGet of homepage
        /// </summary>
        public void OnGet()
        {
            //Products = ProductService.GetAllData();
        }
    }
}