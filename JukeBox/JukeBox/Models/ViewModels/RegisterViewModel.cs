using System.ComponentModel.DataAnnotations;

namespace JukeBox.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(4, ErrorMessage = "Username cannot be shorter than 4 characters")]
        public string UserName { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password cannot be shorter than 8 characters")]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
