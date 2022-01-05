using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public class UserViewModel
    {
        [EmailAddress]
        public string Username { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
