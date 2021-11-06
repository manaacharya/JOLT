using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Creatiin of ErrorModel class to handle errors 
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        //stashing time

        /// <summary>
        /// method to get and set userID 
        /// </summary>
        public string RequestId { get; set; }

        //bool if RequestId is empty or not 
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        //create log category for ErrorModel 
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// initialize logger object 
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {

            _logger = logger;

        }

        /// <summary>
        /// Get the current ID user is logged in with OnGet()
        /// </summary>
        public void OnGet()
        {

            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

        }

    }

}