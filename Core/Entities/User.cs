using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Image { get; set; }

        [NotMapped]
        public string? Token { get; set; }
    }

    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
