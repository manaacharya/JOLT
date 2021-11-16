
namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Create poll model, has title, description and multiple opinions
    /// </summary>
    public class CreatePollModel
    {

        /// <summary>
        /// Method to create title of poll
        /// </summary>
        public string CreateTitle { get; set; }

        /// <summary>
        /// Method to create the description of poll
        /// </summary>
        public string CreateDescription { get; set; }

        /// <summary>
        /// method to create an opinion to be voted on in poll
        /// </summary>
        public string CreateOpinionOne { get; set; }

        /// <summary>
        /// method to create an opinion to be voted on in poll
        /// </summary>
        public string CreateOpinionTwo { get; set; }
    }
}