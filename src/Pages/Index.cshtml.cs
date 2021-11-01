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
        /// <param name="productService"></param> //change this to polls 
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            // ProductService = productService;
        }

        /// <summary>
        /// get method for ProductServices to display on homepage 
        /// </summary>
        // public JsonFileProductService ProductService { get; }

        /// <summary>
        /// list of ProductModel with get and private set 
        /// </summary>
        // public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Dispaly all products on OnGet of homepage
        /// </summary>
        public void OnGet()
        {
            //Products = ProductService.GetAllData();
        }
    }
}