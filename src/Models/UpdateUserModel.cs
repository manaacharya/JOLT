using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    
    /// <summary>
    /// Model for handling the update of users in database user.json
    /// User must alread exist for update
    /// </summary>
    public class UpdateUserModel
    {
        /// <summary>
        /// get set for updating the unique ID 
        /// </summary>
        public int UpdateID { get; set; }

        /// <summary>
        /// get and set for updating string name of user
        /// </summary>
        public string UpdateName { get; set; }

        /// <summary>
        /// get and set for updating string email of user
        /// </summary>
        public string UpdateEmail { get; set; }

        /// <summary>
        /// get and set of string location of user
        /// </summary>
        public string UpdateLocation { get; set; }

        /// <summary>
        /// get and set of updating password of user
        /// password has requirements in order to be password
        /// min of 6 characters
        /// </summary>
        public string UpdatePassword { get; set; }
    }
}
