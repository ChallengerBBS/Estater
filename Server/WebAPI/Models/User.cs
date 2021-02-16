namespace WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public byte[] Password { get; set; }

        public byte[] PasswordKey { get; set; }

    }
}
