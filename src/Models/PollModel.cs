using System.Collections.Generic;

/// <summary>
/// Model for handling poll operation and poll database polls.json
/// </summary>
namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Class for polls for users to vote and participate in
    /// </summary>
    public class PollModel
    {
        /// <summary>
        /// get and set method pollId
        /// Unique identifier of each poll 
        /// </summary>
        public int PollID { get; set; }

        /// <summary>
        /// get and set the userId of the creator of the poll
        /// each poll has to be created by a user with a
        /// unique poll ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// get and set of title of poll 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// get and set 
        /// Summary of what the poll is about 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Collection of Opinions for the Polls
        /// </summary>
        public IEnumerable<OpinionItem> OpinionItems { get; set; }
    }
}