using System.ComponentModel.DataAnnotations;

namespace JukeBox_API.Models.DTOs
{
    public class Login
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}
