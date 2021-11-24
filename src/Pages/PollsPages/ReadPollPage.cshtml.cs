using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Pages.PollsPages
{

    /// <summary>
    /// Read Poll Page Class
    /// </summary>
    public class ReadPollPageModel : PageModel
    {

        /// <summary>
        /// Setting logger
        /// </summary>
        private readonly ILogger<ReadPollPageModel> _logger;

        /// <summary>
        /// Poll Services
        /// </summary>
        public JsonFilePollService PollServices { get; }

        /// <summary>
        /// User Services
        /// </summary>
        public JsonFileUserService UserService { get; }

        /// <summary>
        /// Poll Model for Poll
        /// </summary>
        public PollModel PollModel { get; private set; }

        /// <summary>
        /// Opinion Items Json Holder
        /// </summary>
        public string OpinionJsonData { get; private set; }

        /// <summary>
        /// Author of Poll
        /// </summary>
        public UserModel Author { get; private set; }

        /// <summary>
        /// Constructor for Read Poll Page
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="jsonFilePollService"></param>
        /// <param name="jsonFileUserService"></param>
        public ReadPollPageModel(ILogger<ReadPollPageModel>
            logger, JsonFilePollService jsonFilePollService,
            JsonFileUserService jsonFileUserService)
        {
            //create logger
            _logger = logger;

            //assign pollservices 
            PollServices = jsonFilePollService;

            // assign userservices
            UserService = jsonFileUserService;
        }

        /// <summary>
        /// OnGet ActionResult for Read Poll Page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {
            // Check if ID is valid
            if (id < 0)
            {
                // Redirect to Index Page
                return RedirectToPage("/Index");
            }

            // Get A Poll
            PollModel = PollServices.GetPoll(id);

            // Get the OpinionItems as Json
            OpinionJsonData =
                PollServices.GetOpinionsJsons(PollModel.OpinionItems);

            // Get the Author or User of the Poll
            Author = UserService.GetUser(PollModel.UserID);

            // Redirect to Page
            return Page();
        }
    }
}