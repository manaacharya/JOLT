using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Model for handling poll operation and poll database polls.json
/// </summary>
namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// OpinionItem is a poll with a name and counts to each opinion
    /// </summary>
    public struct OpinionItem
    {
        /// <summary>
        /// get and set the string of each opinion item
        /// One poll can have multiple opinions 
        /// </summary>
        public string opinionName { get; set; }

        /// <summary>
        /// get and set numCounts
        /// number of votes for each opinion in one poll 
        /// </summary>
        public int numCounts { get; set; }

        /// <summary>
        /// OpinionItem constructor 
        /// </summary>
        /// <param name="name"></param> opinion information 
        /// <param name="count"></param> count of vote 
        public OpinionItem(string name, int count)
        {
            this.opinionName = name;
            this.numCounts = count;
        }
    };

    /// <summary>
    /// Class for polls for users to vote and partcipate in
    /// </summary>
    public class PollModel
    {
        /// <summary>
        /// get and set method pollId
        /// Unique identifier of each poll 
        /// </summary>
        public int pollID { get; set; }

        /// <summary>
        /// get and set the userId of the creator of the poll
        /// each poll has to be created by a user with a
        /// unique poll ID
        /// </summary>
        public int userID { get; set; }

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
