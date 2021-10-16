using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class UserModel
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string location { get; set; }

        public override string ToString() => JsonSerializer.Serialize<UserModel>(this);

 
    }
}