using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Error model class created to handle errors in website
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        /// <summary>
        /// method to get and set userID 
        /// </summary>
        public string RequestId { get; set; }


        /// <summary>
        ///bool if RequestId is empty or not 
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        //create log category for ErrorModel 
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// initialize logger object 
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            //setting logger
            _logger = logger;
        }

        /// <summary>
        /// Get the current ID user is logged in with OnGet()
        /// </summary>
        public void OnGet()
        {
            //get requested onGet()
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}