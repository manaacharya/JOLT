
namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Create poll model, has title, description and multiple opinions
    /// </summary>
    public class CreatePollModel
    {
        /// <summary>
        /// Author Attribute
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Attributes for title of poll
        /// </summary>
        public string CreateTitle { get; set; }

        /// <summary>
        /// Attributes for description of poll
        /// </summary>
        public string CreateDescription { get; set; }

        /// <summary>
        /// Attributes for Poll One
        /// </summary>
        public string CreateOpinionOne { get; set; }

        /// <summary>
        /// Attributes for Poll Two
        /// </summary>
        public string CreateOpinionTwo { get; set; }
    }
}