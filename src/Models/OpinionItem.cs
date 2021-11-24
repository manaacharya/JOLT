/// <summary>
/// Class to store opinions
/// </summary>
namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Two opinion items in each poll, each has a specific number count
    /// </summary>
    public class OpinionItem
    {
        /// <summary>
        /// get and set the string of each opinion item
        /// One poll can have multiple opinions 
        /// </summary>
        public string OpinionName { get; set; }

        /// <summary>
        /// get and set numCounts
        /// number of votes for each opinion in one poll 
        /// </summary>
        public int NumCounts { get; set; }

        public OpinionItem() { }

        /// <summary>
        /// OpinionItem constructor 
        /// </summary>
        /// <param name="opinionName"></param> opinion information 
        /// <param name="numCounts"></param> count of vote 
        public OpinionItem(string opinionName, int numCounts)
        {
            //set opinionname as parameter, name must match attribute (camelCase)
            this.OpinionName = opinionName;

            //set numcounts as parameter, name must match attribute (camelCase)
            this.NumCounts = numCounts;
        }
    }
}