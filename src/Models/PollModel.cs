using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public struct OpinionItem
    {
        public string opinionName { get; set; }
        public int numCounts { get; set; }

        public OpinionItem(string name, int count)
        {
            this.opinionName = name;
            this.numCounts = count;
        }
    };

    public class PollModel
    {
        public int pollID { get; set; }
        public int userID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Collection of Opinions for the Polls
        // public List<OpinionItem> OpinionItems { get; set; }

        public IEnumerable<OpinionItem> OpinionItems { get; set; }
    }
}
