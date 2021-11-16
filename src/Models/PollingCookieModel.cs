using System.Collections.Generic;

/// <summary>
/// Class for holding cookies used to remember user login 
/// </summary>
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