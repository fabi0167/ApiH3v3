using System.ComponentModel.DataAnnotations;

namespace ApiH3v3
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
