using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    public class RegisterModel : PageModel
    {

        // Data middletier
        public JsonFileUserService UserService { get; }
        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userService"></param>
        public RegisterModel(JsonFileUserService userService)
        {
            UserService = userService;
        }
        // The data to show, bind to it for the post
        [BindProperty]
        public UserModel User{ get; set; }

        /*public RegisterModel(ILogger<RegisterModel> logger)
        {
            _logger = logger;
        }*/

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            User = UserService.GetUsers().FirstOrDefault(m => m.userID.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable User
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserService.UpdateData(User);

            return RedirectToPage("./Index");
        }


    }
}
