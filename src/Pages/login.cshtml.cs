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
    public class LoginModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public LoginModel(ILogger<IndexModel> logger,
            JsonFileUserService userService)
        {
            _logger = logger;
            UserService = userService;
        }

        public JsonFileUserService UserService { get; }
        public IEnumerable<UserModel> UserList { get; private set; }
        public void OnGet() => UserList = UserService.GetUsers();

        public string CurrentUsername { get; set; }
        public string CurrentPassword { get; set; }

        public Boolean isValidUser()
        {
            return false;
        }


    }
}
