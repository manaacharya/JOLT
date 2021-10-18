using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    
    // -------  Model For Update User --------
    public class UpdateUserModel
    {
        public int UpdateID { get; set; }

        public string UpdateName { get; set; }

        public string UpdateEmail { get; set; }

        public string UpdateLocation { get; set; }

        public string UpdatePassword { get; set; }
    }
}
