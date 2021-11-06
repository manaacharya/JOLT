using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
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

        /// <summary>
        /// OpinionItem constructor 
        /// </summary>
        /// <param name="name"></param> opinion information 
        /// <param name="count"></param> count of vote 
        public OpinionItem(string name, int count)
        {
            //set opinionname as parameter 
            this.OpinionName = name;
            //set numcounts as parameter
            this.NumCounts = count;
        }
    }
}
