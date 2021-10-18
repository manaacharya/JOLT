using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
{
    public class Login_WelcomeModel : PageModel
    {
        public object Username { get; private set; }

        public void OnGet()
        {
            // SUsername = HttpContext.Session.GetString("Username");
        }

        public IActionResult OnGetLogout()
        {
            // HttpContext.Session.Remove("Username");

            // return RedirectToPage("Home page");
            return Page();
        }
    }
}
