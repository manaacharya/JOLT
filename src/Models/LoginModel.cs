using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public class  UserLoginModel
    {
        [Required(ErrorMessage = "* This field is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "* This field is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "* Must be at least 6 characters long")]
        public string password { get; set; }
    }
}
