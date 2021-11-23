using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Pages.PollsPages
{
    public class ReadPollPageModel : PageModel
    {

        /// <summary>
        /// Setting logger
        /// </summary>
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Poll Services
        /// </summary>
        public JsonFilePollService PollServices { get; }

        public JsonFileUserService UserService { get; }

        public PollModel PollModel { get; private set; }

        public string OpinionJsonData { get; private set; }

        public UserModel Author { get; private set; }


        public ReadPollPageModel(ILogger<IndexModel> logger, JsonFilePollService jsonFilePollService, JsonFileUserService jsonFileUserService)
        {
            //create logger
            _logger = logger;

            //create pollservices 
            PollServices = jsonFilePollService;

            UserService = jsonFileUserService;
        }

        public IActionResult OnGet(int id)
        {
            if (id < 0)
            {
                return RedirectToPage("/Index");
            }

            PollModel = PollServices.GetPoll(id);

            OpinionJsonData = PollServices.GetOpinionsJsons(PollModel.OpinionItems);

            Author = UserService.GetUser(PollModel.UserID);

            return Page();
        }
    }
}
