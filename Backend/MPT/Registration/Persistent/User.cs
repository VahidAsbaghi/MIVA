using System.ComponentModel.DataAnnotations;

namespace Registration.Persistent
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        [EmailAddress]
        public string Email { get; set; }

    }
}
