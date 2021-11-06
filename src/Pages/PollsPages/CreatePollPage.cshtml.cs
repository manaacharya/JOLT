using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.PollsPages
{
    public class CreatePollPageModel : PageModel
    {
        public string Message { get; set; }

        private readonly ILogger<CreatePollPageModel> _logger;

        public JsonFileUserService UserServices { get; set; }

        public JsonFilePollService PollService { get; set; }

        public string CookieNameValue { get; }

        [BindProperty]
        public CreatePollModel CreatePoll { get; set; }

        public CreatePollPageModel(ILogger<CreatePollPageModel> logger,
            JsonFileUserService userService, JsonFilePollService pollService)
        {
            _logger = logger;
            UserServices = userService;
            PollService = pollService;
            CookieNameValue = UserServices.GetCookieValue("nameCookie");
        }

        public void OnGet()
        {
            Message = $"Welcome {CookieNameValue}:  Create Your Amazing Poll";
        }

        public IActionResult OnPost()
        {
            UserModel getUser = UserServices.GetUser(CookieNameValue);

            if(getUser == null)
            {
                RedirectToPage("PollsPage");
            }

            PollModel pollCreationStatus = PollService.CreatePoll(CreatePoll, getUser.UserID);

            if(pollCreationStatus == null)
            {
                Message = $"Something Went Wrong Try Again";
                return Page();
            }

            Message = $"Awesome {pollCreationStatus.Title} Created: Make Another Poll";

            return Page();
        }
    }
}
