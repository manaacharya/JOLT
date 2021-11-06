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

        [BindProperty]
        public CreatePollModel CreatePoll { get; set; }

        public CreatePollPageModel(ILogger<CreatePollPageModel> logger,
            JsonFileUserService userService, JsonFilePollService pollService)
        {
            _logger = logger;
            UserServices = userService;
            PollService = pollService;
        }

        public void OnGet()
        {
            Message = $"Welcome Create Your Polls";
        }

        public IActionResult OnPost()
        {
            var cookieValue = UserServices.GetCookieValue("nameCookie"); //Request.Cookies["nameCookie"];

            var getUser = UserServices.GetUser(cookieValue.ToString());

            var pollCreationStatus = PollService.CreatePoll(CreatePoll, getUser.UserID);

            if(pollCreationStatus == null)
            {
                return Page();
            }

            return RedirectToPage("PollsPage");
        }
    }
}
