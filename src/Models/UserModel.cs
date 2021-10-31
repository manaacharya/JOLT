using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Model for handling user operations and user database users.json
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// get and set userId
        /// unique userId given at random to user when created in userServices
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// get set string username of user specific to ID 
        /// </summary>
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "* Must only include letters or numbers")]
        [Required(ErrorMessage = "* This field is required")]
        public string Username { get; set; }

        /// <summary>
        /// get set password of userID
        /// required minimum length of 6 characters
        /// required field 
        /// </summary>
        [Required(ErrorMessage = "* This field is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "* Must be at least 6 characters long")]
        public string Password { get; set; }

        /// <summary>
        /// get set email for userID
        /// required field 
        /// </summary>
        [EmailAddress(ErrorMessage = "* Enter a valid email")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "* Must be an email address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "* This field is required")]
        public string Email { get; set; }

        /// <summary>
        /// get and set location for userID
        /// required field
        /// can only use characters 
        /// </summary>
        [RegularExpression("^[a-zA-Z' ']+$", ErrorMessage = "* Location can only have letters")]
        [Required(ErrorMessage = "* This field is required")]
        public string Location { get; set; }

        /// <summary>
        /// toString methof of user object
        /// includes userID, username, password, email and location
        /// </summary>
        /// <returns></returns>
        public override string ToString() => JsonSerializer.Serialize<UserModel>(this);

 
    }
}