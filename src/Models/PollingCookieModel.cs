using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Cookie Class for Polling
    /// </summary>
    public class PollingCookieModel
    {
        /// <summary>
        /// Dictionary collection of key-value pairs
        /// </summary>
        public Dictionary<string, string> CookieCollection { get; set; }
    }
}
