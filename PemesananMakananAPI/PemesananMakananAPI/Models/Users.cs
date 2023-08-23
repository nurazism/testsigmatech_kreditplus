using System.ComponentModel.DataAnnotations;

namespace PemesananMakananAPI.Models
{
    public class Users
    {
        [Key]
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
