using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class AboutUsModel : PageModel
    {   

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
