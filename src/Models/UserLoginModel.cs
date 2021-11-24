using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model for handling user login and user database user.json
    /// </summary>
    public class  UserLoginModel
    {
        /// <summary>
        /// get and set user name method for user name in user services
        /// required field for login 
        /// </summary>
        [Required(ErrorMessage = "* This field is required")]
        public string Username { get; set; }

        /// <summary>
        /// get and set method for password in user services 
        /// required to min 6 characters and field is required for login 
        /// </summary>
        [Required(ErrorMessage = "* This field is required")]
        public string Password { get; set; }
    }
}